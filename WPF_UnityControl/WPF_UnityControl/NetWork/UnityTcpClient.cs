using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows;

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

        /// <summary> 受信完了イベント </summary>
        public Action<string> OnUnityConnected = (msg) => { };

        /// <summary> 受信完了イベント </summary>
        public Action<bool> IsSending = (isSend) => { };

        /// <summary> 受信完了イベント </summary>
        public Action<bool> OnConnected = (onConnected) => { };
        #endregion

        /// <summary>
        /// 接続処理
        /// </summary>
        public async Task ConnectAsync()  // 引数にIPとPORTを渡す設計に変更予定
        {
            try
            {
                if (_client?.Connected == true)
                {
                    Dispose();
                    OnConnected(false);
                    OnUnityConnected($"Unity接続 >>> 切断しました。");
                    return;
                }

                IsSending(true);
                await Task.Delay(2000);
                _client = new TcpClient();
                await _client.ConnectAsync(SERVER_IP, SERVER_PORT);
                _stream = _client.GetStream();
                _ = ReceiveLoopAsync(); // 受信監視開始

                OnUnityConnected($"Unity接続 >>>接続しました");

                OnConnected(true);
            }
            catch (SocketException e)
            {
                OnUnityConnected($"Unity接続 >>> 接続に失敗しました。\r\n{e.Message}");
            }
            finally
            {
                IsSending(false);
            }
        }

        /// <summary>
        /// Unityサーバーからのデータを非同期で受信
        /// </summary>
        private async Task ReceiveLoopAsync()
        {

            if (_stream == null)
                return;

            IsSending(true);

            var buffer = new byte[4096];

            try
            {
                while (_client?.Connected == true)
                {
                    var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);


                    if (bytesRead == 0) break;


                    string receivedJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (!string.IsNullOrEmpty(receivedJson))
                    { // 受信があったときのイベント発行
                        OnReceived?.Invoke(receivedJson);
                    }
                }

                if (_client?.Connected == true) 

                OnConnected(false);
                OnUnityConnected($"Unity接続 >>> 切断されました。");
            }
            catch (Exception ex)
            {
                OnUnityConnected($"データ受信確認中、異常が発生ました。\r\n{ex}");
            }
            finally
            {
                IsSending(false);
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