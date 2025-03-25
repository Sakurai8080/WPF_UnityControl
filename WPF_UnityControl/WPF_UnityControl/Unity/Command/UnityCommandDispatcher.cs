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
        #endregion

        #region プロパティ
        public TcpClientController TCPController { get { return _tcpController; } }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tcpController">TCP操作</param>
        public UnityCommandDispatcher()
        {
            var tcp = new UnityTcpClient();
            _tcpController = new TcpClientController(tcp);
            _cmdGenerator = new CommandGenerator();
        }

        /// <summary>
        /// コマンド送信開始
        /// </summary>
        /// <param name="cmd">コマンドタイプ</param>
        /// <param name="parameters">コマンドに応じたパラメータ</param>
        public void BeginSendCommand(CommandType cmd, string[]? parameters = null)
        {
            var cmdJson = _cmdGenerator.GenerateJsonCommand(cmd, parameters);
            _ = _tcpController.SendCommandAsync(cmdJson);
        }
    }
}
