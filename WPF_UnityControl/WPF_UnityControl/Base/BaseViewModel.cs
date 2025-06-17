using System.Reactive.Disposables;

namespace WPF_UnityControl.Base
{
    /// <summary>
    /// ViewModelの基底クラス
    /// </summary>
    public abstract class BaseViewModel : IDisposable
    {

        #region プロパティ
        /// <summary>
        /// イベント通知の管理
        /// </summary>
        protected IEventAggregator EventAggregator { get; }

        /// <summary>
        /// ReactivePropertyの購読破棄オブジェクト
        /// </summary>
        protected CompositeDisposable Disposables { get; } = new CompositeDisposable();
        #endregion
        #region フィールド
        /// <summary>
        /// EventAggregatorイベントとトークンリストの保持
        /// </summary>
        protected List<(EventBase eventInstance, SubscriptionToken token)> _eventTokenList = new();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント管理(DI)</param>
        protected BaseViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }
        #endregion

        /// <summary>
        /// 購読イベントとトークンの登録
        /// </summary>
        /// <param name="eventInstance"></param>
        /// <param name="token"></param>
        protected void AddEventToken(EventBase eventInstance, SubscriptionToken token)
        {
            _eventTokenList.Add((eventInstance, token));
        }

        /// <summary>
        /// リソース破棄
        /// </summary>
        public virtual void Dispose()
        {
            Disposables?.Dispose();

            _eventTokenList.ForEach(pair => pair.eventInstance.Unsubscribe(pair.token));
            _eventTokenList.Clear();
        }
    }
}
