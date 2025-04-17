using WPF_UnityControl.Response;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {
        #region フィールド
        /// <summary> Unityへの送信管理インスタンス </summary>
        private readonly UnityCommandDispatcher _unityDsp;

        /// <summary> レスポンス管理インスタンス </summary>
        private readonly ResponseController _resController;

        /// <summary> シーン一覧レスポンスインスタンス </summary>
        public readonly SceneListResponse _sceneListResponse;

        /// <summary> ヒエラルキーレスポンスインスタンス </summary>
        public readonly HierarchyResponse _hierarchyResponse;
        #endregion
        #region プロパティ
        /// <summary> シーン一覧レスポンスインスタンス </summary>
        public SceneListResponse SceneResponse => _sceneListResponse;

        /// <summary> ヒエラルキーレスポンスインスタンス </summary>
        public HierarchyResponse HierarchyReponse => _hierarchyResponse;
        #endregion
        #region コンストラクタ
        public UnityController()
        {
            _unityDsp = new UnityCommandDispatcher();
            _resController = new ResponseController();
            _sceneListResponse = new SceneListResponse();
            _hierarchyResponse = new HierarchyResponse();

            // タイプとレスポンス処理の登録
            _resController.ResponceCommandRegister(CommandType.SCENE_FETCH, SceneResponse);
            _resController.ResponceCommandRegister(CommandType.FETCH_HIERARCHY, HierarchyReponse);

            // イベント登録
            _unityDsp.TCPController.OnJsonResponse = (json) => _resController?.HandleResponse(json);
        }
        #endregion

        /// <summary>
        /// Unity接続処理
        /// </summary>
        public void UnityConnetChange()
        {
            _ = _unityDsp.TCPController.ConnectToUnityAsync();
        }

        /// <summary>
        /// Unityシーン一覧取得
        /// </summary>
        public async Task FetchUnityScene()
        {
            await _unityDsp.BeginSendCommand(CommandType.SCENE_FETCH);
        }

        /// <summary>
        /// Unityシーンの変更
        /// </summary>
        /// <param name="sceneName">シーンの変更</param>
        public async Task UnitySceneChenge(string sceneName)
        {
            await _unityDsp.BeginSendCommand(CommandType.SCENE_CHANGE, sceneName);
        }

        /// <summary>
        /// Unityの現在開いているシーンのヒエラルキー取得
        /// </summary>
        public async Task FetchUnityHierarchy()
        {
            await _unityDsp.BeginSendCommand(CommandType.FETCH_HIERARCHY);
        }

        /// <summary>
        /// オブジェクト作成
        /// </summary>
        public void SetGameObjectPosition()
        {
            string[] prm = { "TestObject", "1", "2", "3" };
            _unityDsp?.BeginSendCommand(CommandType.OBJECT_MOVE, prm);
        }
    }
}
