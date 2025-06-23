using Newtonsoft.Json;
using WPF_UnityControl.Base;
using WPF_UnityControl.Events;
using WPF_UnityControl.Interface;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// シーン一覧専用レスポンスクラス
    /// </summary>
    public class SceneListResponse : BaseResponse, IResponseData
    {
        #region プロパティ
        /// <summary>
        /// コマンドタイプ
        /// </summary>
        public CommandType CommandType => CommandType.SCENE_FETCH;
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント通信管理</param>
        public SceneListResponse(IEventAggregator eventAggregator) : base(eventAggregator){}
        #endregion

        /// <summary>
        /// レスポンス処理の実行
        /// </summary>
        /// <param name="json">受信したJson</param>
        public void Execute(string json)
        {
            var scenes = JsonConvert.DeserializeObject<string[]>(json);
            if (scenes?.Length >= 1)
            {
                ResponseToList(scenes);
            }
        }

        /// <summary>
        /// Jsonファイルのシーン一覧をコレクションに格納
        /// </summary>
        /// <param name="scenes">シーン一覧</param>
        public void ResponseToList(string[] scenes)
        {
            var sceneList = scenes?.ToList() ?? new();
            // シーン一覧取得イベント発行
            _eventAggregator?.GetEvent<SceneListUpdateEvent>().Publish(sceneList);
        }
    }
}
