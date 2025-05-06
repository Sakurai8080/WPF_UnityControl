using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Windows.Data;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ヒエラルキーTree表示用ViewModel
    /// </summary>
    public class HierarchyControlViewModel : IDisposable
    {
        #region フィールド
        /// <summary> 購読管理オブジェクト </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> イベント仲介オブジェクト </summary>
        private readonly IEventAggregator _eventAggregator;

        private readonly UnityController _controller;
        #endregion
        #region プロパティ
        /// <summary> ヒエラルキー表示データ </summary>
        public ReactivePropertySlim<List<HierarchyNode>> HierarchyTree { get; } = new ReactivePropertySlim<List<HierarchyNode>>();
        public ReactivePropertySlim<string> SelectedName { get; } = new ReactivePropertySlim<string>();
        #endregion
        #region コンストラクタ
        public HierarchyControlViewModel(IEventAggregator eventAggregator, UnityController controller)
        {
            _eventAggregator = eventAggregator;
            _controller = controller;

            _eventAggregator.GetEvent<HierarchyFetchedEvent>()
                            .Subscribe(nodes =>
                            {
                                HierarchyTree.Value = nodes;
                            })
                            .AddTo(_disposables);

            SelectedName.Subscribe( async name => await _controller.FetchObjectData(name));
        }
        #endregion

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
