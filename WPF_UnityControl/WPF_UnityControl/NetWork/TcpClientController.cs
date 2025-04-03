using System.Text;

namespace WPF_UnityControl.NetWork
{
    /// <summary>
    /// TCP経由でデータの送受信を操作するクラス
    /// </summary>
    public class TcpClientController 
    {
        #region フィールド
        /// <summary> Unity接続インスタンス</summary>
        private readonly UnityTcpClient _tcp;
        #endregion
        #region プロパティ
        public Action<string> OnJsonResponse = (json) => { };
        #endregion
        #region コンストラクタ
        public TcpClientController()
        {
            _tcp = new UnityTcpClient();

            _tcp.OnReceived += json =>
            { // Jsonの受け取り
                OnJsonResponse(json);
            };
        }
        #endregion

        /// <summary>
        /// TCPサーバーへの接続
        /// </summary>
        public async Task ConnectToUnityAsync()
        {
            await _tcp.ConnectAsync();
        }

        /// <summary>
        /// コマンドの送信   
        /// </summary>
        /// <param name="message">Unityに流すコマンド</param>
        public async Task SendCommandAsync(string message)
        {
            if (_tcp.Stream == null) return;

            byte[] data = Encoding.UTF8.GetBytes(message + "\n"); 　// コマンドをバイト配列に変換
            await _tcp.Stream.WriteAsync(data, 0, data.Length);
        }

    }
}
