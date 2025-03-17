using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace WPF_UnityControl.NetWork
{
    /// <summary>
    /// TCPの接続状態管理
    /// </summary>
    public class UnityTcpClient : IDisposable
    {
        #region 定数フィールド
        /// <summary> 接続先のサーバーIPアドレス(ローカルホスト) </summary>
        private const string SERVER_IP = "127.0.0.1";

        /// <summary> TCPサーバーと通信するためのポート番号 </summary>
        private const int SERVER_PORT = 5000;
        #endregion
        #region フィールド
        /// <summary>  TCPクライアント </summary>
        private TcpClient? _client;
        
        /// <summary> データの送受信するネットワークストリーム(TcpClientから取得)</summary>
        private NetworkStream? _stream;
        #endregion
        #region プロパティ
        /// <summary> データ送受信ストリーム </summary>
        public NetworkStream? Stream => _stream;

        /// <summary> 接続中フラグ </summary>
        public bool IsConnected => _client?.Connected ?? false;
        #endregion

        /// <summary>
        /// 接続処理
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()  // 引数にIPとPORTを渡す設計に変更予定
        {
            try
            {
                if (_client?.Connected == true)  return;
              

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
     
        public void Close()
        {
            _stream?.Close();
            _client?.Close();
        }
        public void Dispose()
        {
            Close();
        }

    }
}