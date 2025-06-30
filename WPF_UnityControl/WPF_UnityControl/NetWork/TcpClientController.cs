using System.Text;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.NetWork
{
    /// <summary>
    /// TCP経由でデータの送受信を操作するクラス
    /// </summary>
    public class TcpClientController 
    {
        #region フィールド
        /// <summary> 
        /// Unity接続インスタンス
        /// </summary>
        private readonly UnityTcpClient _tcp;

        /// <summary>
        /// レスポンス操作クラスインスタンス
        /// </summary>
        private readonly ResponseController _resCon;
        #endregion
        #region デリゲート
        /// <summary>
        /// 接続状態イベント
        /// </summary>
        public event EventHandler<UnityConnectionEventArgs> UnityConnectionChanged = (s, e) => { };
        
        /// <summary>
        /// レスポンスデータ受信イベント
        /// </summary>
        public Action<string> OnResponseReceive = (json) => { };

        /// <summary>
        /// コマンド送信中イベント
        /// </summary>
        public Action<bool> IsSending = (isSending) => { };
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="resCon">レスポンス操作クラス DI</param>
        public TcpClientController(ResponseController resCon)
        {
            _resCon = resCon;
            _tcp = new UnityTcpClient();

            #region イベント登録
            _tcp.OnReceivedJson += json =>
            { // Jsonの受け取り
                _resCon.HandleResponse(json);
            };

            _tcp.UnityConnectionChanged += (s ,e) =>
            { // Unityの接続状態メッセージ管理
                UnityConnectionChanged?.Invoke(s, e);
            };

            _resCon.OnResponseReceive += (msg) =>
            { // Unityレスポンスデータ表示
                var now = DateTime.Now;
                OnResponseReceive($"[情報 : {now} ] >>> {msg}\r\n");
            };

            _tcp.IsSending += (isSend) =>
            { // Unityへの送信状態管理
                IsSending(isSend);
            };
            #endregion
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
