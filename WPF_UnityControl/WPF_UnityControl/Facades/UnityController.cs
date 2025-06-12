using ControlzEx.Standard;
using Reactive.Bindings;
using WPF_UnityControl.JsonPoco;
using WPF_UnityControl.Models;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {
        #region フィールド
        /// <summary> Unityへの送信管理インスタンス </summary>
        private readonly UnityCommandDispatcher _unityDsp;
        #endregion
        #region デリゲート
        /// <summary> 受信完了イベント </summary>
        public Action<string> OnUnityConnected = (msg) => { };

        /// <summary> 受信完了イベント </summary>
        public Action<string> OnResponseReceive = (msg) => { };

        public Action<bool> IsSending = (isSending) => { };

        public Action<bool> OnConnected = (onConnected) => { };

        #endregion
        #region コンストラクタ
        public UnityController(UnityCommandDispatcher commandDispatcher)
        {
            _unityDsp = commandDispatcher;

            _unityDsp.TCPController.OnUnityConnected += (msg) =>
            {
                OnUnityConnected(msg);
            };

            _unityDsp.TCPController.OnResponseReceive += (msg) =>
            {
                OnResponseReceive(msg);
            };

            _unityDsp.TCPController.IsSending += (isSending) =>
            {
                IsSending(isSending);
            };

            _unityDsp.TCPController.OnConnected += (onConnected) =>
            {
                OnConnected(onConnected);
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
                var jsonObj = new JsonGameObject
                {
                    Name = objInfo.Name,
                    Tag = objInfo.Tag,
                    Layer = objInfo.Layer,
                    IsActive = objInfo.IsActive,
                    Transform = new JsonTransform
                    {
                        Position = new JsonVector3
                        {
                            X = objInfo.Transform.Position.X.Value,
                            Y = objInfo.Transform.Position.Y.Value,
                            Z = objInfo.Transform.Position.Z.Value,
                        },
                        Rotation = new JsonVector3
                        {
                            X = objInfo.Transform.Rotation.X.Value,
                            Y = objInfo.Transform.Rotation.Y.Value,
                            Z = objInfo.Transform.Rotation.Z.Value,
                        },
                        Scale = new JsonVector3
                        {
                            X = objInfo.Transform.Scale.X.Value,
                            Y = objInfo.Transform.Scale.Y.Value,
                            Z = objInfo.Transform.Scale.Z.Value,
                        }

                    }
                };
                _unityDsp?.BeginSendCommand(CommandType.SET_OBJECT_DATA, jsonObj);

            }
        }
    }
}
