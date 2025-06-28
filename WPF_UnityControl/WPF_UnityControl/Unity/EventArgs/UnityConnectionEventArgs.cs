namespace WPF_UnityControl.Unity
{
    /// <summary>
    /// Unity接続通知用データクラス
    /// </summary>
    public class UnityConnectionEventArgs : EventArgs
    {
        #region プロパティ
        /// <summary>
        /// 接続状態
        /// </summary>
        public bool IsConnected { get; }

        /// <summary>
        /// 接続メッセージ
        /// </summary>
        public string Message { get; }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isConnected">接続状態</param>
        /// <param name="message">接続メッセージ</param>
        public UnityConnectionEventArgs(bool isConnected, string message)
        {
            IsConnected = isConnected;
            Message = message;
        }
        #endregion
    }
}
