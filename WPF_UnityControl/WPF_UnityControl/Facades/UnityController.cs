using WPF_UnityControl.Converter;
using WPF_UnityControl.Events;
using WPF_UnityControl.Models;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {
        #region フィールド
        /// <summary> 
        /// Unityへの送信管理インスタンス 
        /// </summary>
        private readonly UnityCommandDispatcher _unityDsp;

        /// <summary> 
        /// イベント通信管理
        /// </summary>
        private IEventAggregator _eventAggregator;
        #endregion
        #region デリゲート
        /// <summary>
        /// Unity接続イベント 
        /// </summary>
        public event EventHandler<UnityConnectionEventArgs> OnUnityConnected = (s, e) => { };

        /// <summary>
        /// レスポンス受信メッセージイベント
        /// </summary>
        public Action<string> OnResponseReceive = (msg) => { };

        /// <summary>
        /// Unity送信中イベント
        /// </summary>
        public Action<bool> OnCommandSending = (isSending) => { };
        #endregion
        #region コンストラクタ
        public UnityController(UnityCommandDispatcher commandDispatcher, IEventAggregator eventAggregator)
        {
            _unityDsp = commandDispatcher;

            _eventAggregator = eventAggregator;

            _unityDsp.TCPController.UnityConnectionChanged += (s, e) =>
            { // Unity接続メッセージイベント登録
                OnUnityConnected?.Invoke(s, e);
                if (!e.IsConnected)
                { // 切断の場合、全値のクリアイベント発行
                    _eventAggregator.GetEvent<ClearAllValuesEvent>().Publish();
                }
            };

            _unityDsp.TCPController.OnResponseReceive += (msg) =>
            { // レスポンス受信イベント登録
                OnResponseReceive(msg);
            };

            _unityDsp.TCPController.IsSending += (isSending) =>
            { // コマンド送信中イベント登録
                OnCommandSending(isSending);
            };
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
        /// オブジェクトデータ取得
        /// </summary>
        /// <param name="objName">選択したオブジェクト</param>
        public async Task FetchObjectData(string objName)
        {
            await _unityDsp.BeginSendCommand(CommandType.GET_OBJECT_DATA, objName);
        }

        /// <summary>
        /// オブジェクトデータの送信
        /// </summary>
        public void SetGameObjectData(GameObjectModel objInfo)
        {
            if (objInfo != null)
            {
                var jsonObj = GameObjectConverter.ToJson(objInfo);
                _unityDsp?.BeginSendCommand(CommandType.SET_OBJECT_DATA, jsonObj);
            }
        }
    }
}
