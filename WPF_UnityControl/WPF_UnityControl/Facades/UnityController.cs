using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {
        #region フィールド
        /// <summary> Unityへの送信管理インスタンス </summary>
        private readonly UnityCommandDispatcher _unityDsp;
        #endregion
        #region コンストラクタ
        public UnityController(UnityCommandDispatcher commandDispatcher)
        {
            _unityDsp = commandDispatcher;
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
