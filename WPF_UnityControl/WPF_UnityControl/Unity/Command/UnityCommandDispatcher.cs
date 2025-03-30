using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.NetWork;

namespace WPF_UnityControl.Unity
{
    /// <summary>
    /// Unityへの送信コマンドを管理するクラス
    /// </summary>
    public class UnityCommandDispatcher
    {
        #region フィールド
        /// <summary>　TCP操作インスタンス </summary>
        private readonly TcpClientController _tcpController;

        /// <summary> コマンド作成インスタンス </summary>
        private readonly CommandGenerator _cmdGenerator;

        private SceneCommandResponse _sceneResponce; //クラス分けする

        private TaskCompletionSource<bool> _sceneResponseReceived = new(); //処理待ちオブジェクト
        #endregion

        #region プロパティ
        public TcpClientController TCPController { get { return _tcpController; } }

        public SceneCommandResponse SceneResponce => _sceneResponce;　// クラス分けする
        #endregion

        public event Action<string> OnReceiveResponse = (msg) => { };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tcpController">TCP操作</param>
        public UnityCommandDispatcher()
        {
            _tcpController = new TcpClientController();
            _cmdGenerator = new CommandGenerator();
         
            _tcpController.OnJsonResponse = (json) =>
            {
                ReceiveSceneData(json);
            };
        }

        /// <summary>
        /// コマンド送信開始
        /// </summary>
        /// <param name="cmd">コマンドタイプ</param>
        /// <param name="parameters">コマンドに応じたパラメータ</param>
        public async Task BeginSendCommand(CommandType cmd, string[]? parameters = null)
        {
            var cmdJson = _cmdGenerator.GenerateJsonCommand(cmd, parameters);
            await _tcpController.SendCommandAsync(cmdJson);
        }

        private void ReceiveSceneData(string json)
        {
            _sceneResponce = new SceneCommandResponse(json);
            _sceneResponseReceived.TrySetResult(true);  // レスポンス受信完了通知
        }

        public async Task WaitForSceneResponseAsync()
        {
            await _sceneResponseReceived.Task;
        }
    }
}
