using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using WPF_UnityControl.Events;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// シーン一覧表示専用ViewModel
    /// </summary>
    public class SceneListControlViewModel : BindableBase, IDisposable
    {
        #region フィールド
        /// <summary> 
        /// 購読管理オブジェクト 
        /// </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> 
        /// イベント通信管理
        /// </summary>
        private IEventAggregator _eventAggregator;
        #endregion
        #region プロパティ
        /// <summary> 
        /// 取得シーン一覧 
        /// </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; } = new ReactivePropertySlim<List<string>>();

        /// <summary> 
        /// 選択したシーン名 
        /// </summary>
        public ReactivePropertySlim<string> SelectedSceneName { get; } = new ReactivePropertySlim<string>(); 
        #endregion
        #region　コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント通信管理</param>
        public SceneListControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<SceneListUpdateEvent>()
                            .Subscribe(sceneList =>
                            { // SceneListの変更通知を購読
                                SceneList.Value = sceneList;
                            });

            SelectedSceneName.Skip(1)
                             .Subscribe(name =>
                             { // シーン一覧から選択時のイベント発行
                                 _eventAggregator.GetEvent<SceneNameChangedEvent>().Publish(name);
                             }).AddTo(_disposables);
        }
        #endregion

        /// <summary>
        /// 購読破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
