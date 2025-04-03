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
        /// <summary> コマンドタイプとレスポンス処理実行の紐づけ </summary>
        private readonly Dictionary<CommandType, IResponseData> _handleDic = new();

        /// <summary>
        /// 辞書への登録
        /// </summary>
        /// <param name="type">コマンドの種類</param>
        /// <param name="handle">Execute実行インスタンス</param>
        public void ResponceCommandRegister(CommandType type, IResponseData handle)
        {
            _handleDic[type] = handle;
        }

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
                        handler.Execute(payloadJson);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"レスポンスハンドリング中にエラー : {ex}");
            }
        }


    }
}
