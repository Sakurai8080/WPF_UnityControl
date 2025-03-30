using System;
using System.Diagnostics;
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

        #region デリゲート
        /// <summary> 受信完了イベント </summary>
        public Action<string> OnReceived = (json) => { };
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
                _ = ReceiveLoopAsync(); // 受信監視開始

                Debug.WriteLine($"接続完了 :{SERVER_IP} - {SERVER_PORT}");
                MessageBox.Show(App.Current.MainWindow, $"接続完了 :{SERVER_IP} - {SERVER_PORT}");
            }
            catch (SocketException e)
            {
                MessageBox.Show(App.Current.MainWindow, $"サーバー接続時にエラーが発生しました : {e.Message}");
            }
        }

        /// <summary>
        /// Unityサーバーからのデータを非同期で受信
        /// </summary>
        /// <returns></returns>
        private async Task ReceiveLoopAsync()
        {
            if (_stream == null)
                return;

            var buffer = new byte[4096];
            var stringBuilder = new StringBuilder();

            try
            {
                while (_client?.Connected == true)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    stringBuilder.Append(receivedText);

                    if (receivedText.TrimEnd().EndsWith("]"))
                    {
                        string completeJson = stringBuilder.ToString();
                        stringBuilder.Clear();
                        if (!string.IsNullOrEmpty(completeJson))
                        {
                            OnReceived?.Invoke(completeJson);
                        }
                    }
                }
            }
            catch( Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
     
        public void Close()
        {
            _stream?.Close();
            _client?.Close();
            _stream = null;
            _client = null;
        }
        public void Dispose()
        {
            Close();
        }

    }
}