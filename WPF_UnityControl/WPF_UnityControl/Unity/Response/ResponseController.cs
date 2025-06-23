using Newtonsoft.Json;
using System.Diagnostics;
using WPF_UnityControl.Interface;

namespace WPF_UnityControl.Unity
{
    /// <summary>
    /// Unityからの受け取ったレスポンスを操作するクラス
    /// </summary>
    public class ResponseController
    {
        #region フィールド
        /// <summary>
        /// コマンドタイプとレスポンス処理実行に紐づけ
        /// </summary>
        private readonly Dictionary<CommandType, IResponseData> _handleDic = new();
        #endregion
        #region イベント
        /// <summary>
        /// レスポンス受け取りメッセージイベント
        /// </summary>
        public Action<string> OnResponseReceive = (msg) => { };
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handlers">全レスポンスクラス</param>
        public ResponseController(IEnumerable<IResponseData> handlers)
        {
            foreach (var handler in handlers)
            {
                _handleDic[handler.CommandType] = handler;
            }
        }
        #endregion

        /// <summary>
        /// レスポンスの確認と処理のハンドリング
        /// </summary>
        /// <param name="receivedJson">Unityから受け取ったJson</param>
        public void HandleResponse(string receivedJson)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<JsonCommand>(receivedJson);
                if (Enum.TryParse<CommandType>(json?.Command, out var commandType))
                {
                    if (_handleDic.TryGetValue(commandType, out var handler))
                    {
                        var payloadJson = JsonConvert.SerializeObject(json.Parameters);
                        OnResponseReceive($"レスポンス : コマンドタイプ [{commandType}]");

                        handler.Execute(payloadJson);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"レスポンスハンドリング中にエラー : {ex}");
            }
        }


    }
}
