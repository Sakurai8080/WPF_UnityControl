namespace WPF_UnityControl.Base
{
    /// <summary>
    /// レスポンスを処理する基底クラス
    /// </summary>
    public abstract class BaseResponse
    {
        #region フィールド
        /// <summary>
        /// イベント通信の管理
        /// </summary>
        protected IEventAggregator _eventAggregator;
        #endregion
        #region コンストラクタ
        protected BaseResponse(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        #endregion
    }
}
