using Newtonsoft.Json;
using WPF_UnityControl.Base;
using WPF_UnityControl.Events;
using WPF_UnityControl.Interface;
using WPF_UnityControl.JsonPoco;
using WPF_UnityControl.Converter;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// ゲームオブジェクトデータのレスポンスクラス
    /// </summary>
    public class ObjectDataResponse : BaseResponse, IResponseData
    {

        #region プロパティ
        /// <summary>
        /// コマンドタイプ
        /// </summary>
        public CommandType CommandType => CommandType.GET_OBJECT_DATA;
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント通信監理</param>
        public ObjectDataResponse(IEventAggregator eventAggregator) : base(eventAggregator) { }
        #endregion

        /// <summary>
        /// レスポンス処理の実行
        /// </summary>
        /// <param name="json">受信したJson</param>
        public void Execute(string json)
        {
            // Jsonを配列に変換
            var formatJson = JsonConvert.DeserializeObject<string[]>(json);

            if (formatJson?.Length >= 1)
            {
                ResponseToObjectData(formatJson);
            }
        }

        /// <summary>
        /// レスポンスのJsonファイルからゲームオブジェクトモデルにマッピング
        /// </summary>
        /// <param name="json">レスポンスのJsonデータ</param>
        private void ResponseToObjectData(string[] json)
        {
            var goJson = JsonConvert.DeserializeObject<JsonGameObject>(json[0]);

            if (goJson != null)
            {
                var gameObjectData = GameObjectConverter.ToModel(goJson);

                if (gameObjectData != null)
                { // ゲームオブジェクトデータのイベント発行
                    _eventAggregator.GetEvent<GameObjectDataFetchedEvent>().Publish(gameObjectData);
                }
            }
        }
    }
}
