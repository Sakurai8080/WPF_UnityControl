using Newtonsoft.Json;
using Reactive.Bindings;
using WPF_UnityControl.Base;
using WPF_UnityControl.Events;
using WPF_UnityControl.Interface;
using WPF_UnityControl.JsonPoco;
using WPF_UnityControl.Models;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// ゲームオブジェクトデータのレスポンスクラス
    /// </summary>
    public class ObjectDataResponse : BaseResponse, IResponseData, ICommandType
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
                var gameObjectData = new GameObjectModel
                { // JsonPOCOをモデルクラスにマッピング
                    Name = goJson.Name,
                    Tag = goJson.Tag,
                    Layer = goJson.Layer,
                    IsActive = goJson.IsActive,
                    Transform = new TransformModel
                    {
                        Position = new Vector3Model
                        {
                            X = new ReactivePropertySlim<float>(goJson.Transform.Position.X),
                            Y = new ReactivePropertySlim<float>(goJson.Transform.Position.Y),
                            Z = new ReactivePropertySlim<float>(goJson.Transform.Position.Z),
                        },
                        Rotation = new Vector3Model
                        {
                            X = new ReactivePropertySlim<float>(goJson.Transform.Rotation.X),
                            Y = new ReactivePropertySlim<float>(goJson.Transform.Rotation.Y),
                            Z = new ReactivePropertySlim<float>(goJson.Transform.Rotation.Z),
                        },
                        Scale = new Vector3Model
                        {
                            X = new ReactivePropertySlim<float>(goJson.Transform.Scale.X),
                            Y = new ReactivePropertySlim<float>(goJson.Transform.Scale.Y),
                            Z = new ReactivePropertySlim<float>(goJson.Transform.Scale.Z),
                        }

                    }
                };

                if (gameObjectData != null)
                { // ゲームオブジェクトデータのイベント発行
                    _eventAggregator.GetEvent<GameObjectDataFetchedEvent>().Publish(gameObjectData);
                }
            }
        }
    }
}
