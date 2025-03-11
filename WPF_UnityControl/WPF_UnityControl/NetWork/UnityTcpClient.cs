using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace WPF_UnityControl.NetWork
{
    /// <summary>
    /// Unityに接続するためのTCPClient
    /// </summary>
    public class UnityTcpClient
    {
        #region フィールド
        /// <summary>  TCPクライアント </summary>
        private TcpClient? _client;
        
        /// <summary> データの送受信するネットワークストリーム(TcpClientから取得)</summary>
        private NetworkStream? _stream;
        #endregion

        #region 定数フィールド
        /// <summary> 接続先のサーバーIPアドレス(ローカルホスト) </summary>
        private const string SERVER_IP = "127.0.0.1";

        /// <summary> TCPサーバーと通信するためのポート番号 </summary>
        private const int SERVER_PORT = 5000;
        #endregion

        /// <summary>
        /// 接続処理
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(SERVER_IP, SERVER_PORT);
                _stream = _client.GetStream();
                MessageBox.Show(App.Current.MainWindow, $"接続完了 :{SERVER_IP} - {SERVER_PORT}");
            }
            catch (SocketException e)
            {
                MessageBox.Show(App.Current.MainWindow, $"サーバー接続時にエラーが発生しました : {e.Message}");
            }
        }

        /// <summary>
        /// コマンドの送信    // この関数はUnityCommandDispatcherクラス等に持っていく。そのクラスでこのClient or ClientControllerを操作する。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendCommandAsync(string message)
        {
            if (_stream == null) return;

            byte[] data = Encoding.UTF8.GetBytes(message + "\n"); 　// コマンドをバイト配列に変換
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public void Close()
        {
            _stream?.Close();
            _client?.Close();
        }

    }
}