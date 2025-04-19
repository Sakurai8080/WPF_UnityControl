
namespace WPF_UnityControl.Base
{
    /// <summary>
    /// レスポンスを処理する基底クラス
    /// </summary>
    public abstract class BaseResponse
    {
        protected IEventAggregator _eventAggregator;
        protected BaseResponse(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
