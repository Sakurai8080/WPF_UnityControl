using Reactive.Bindings;
using System.Reactive.Linq;
using WPF_UnityControl.Events;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// シーン一覧表示専用ViewModel
    /// </summary>
    public class SceneListControlViewModel : BindableBase
    {
        #region フィールド
        /// <summary> イベントアグリゲーター </summary>
        private IEventAggregator _eventAggregator;
        #endregion
        #region プロパティ
        /// <summary> シーン一覧 </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; } = new ReactivePropertySlim<List<string>>();

        /// <summary> 選択したシーン名 </summary>
        public ReactivePropertySlim<string> SelectedSceneName { get; } = new ReactivePropertySlim<string>(); 
        #endregion
        #region　コンストラクタ
        public SceneListControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SceneListUpdateEvent>().Subscribe(sceneList =>
            { // SceneListの変更通知を購読
                SceneList.Value = sceneList;
            });

            SelectedSceneName.Skip(1).Subscribe(name => _eventAggregator.GetEvent<SceneNameChangedEvent>().Publish(name));
        }
        #endregion
    }
}
