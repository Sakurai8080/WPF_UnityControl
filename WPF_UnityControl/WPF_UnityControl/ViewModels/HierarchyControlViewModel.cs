using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Events;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.ViewModels
{
    public class HierarchyControlViewModel : IDisposable
    {

        /// <summary> 購読管理オブジェクト </summary>
        private readonly CompositeDisposable _disposables = new();

        public ReactivePropertySlim<List<HierarchyNode>> HierarchyTree { get; } = new ReactivePropertySlim<List<HierarchyNode>>();

        private readonly IEventAggregator _eventAggregator;

        public HierarchyControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<HierarchyFetchedEvent>()
                            .Subscribe(nodes =>
                            {
                                HierarchyTree.Value = nodes;
                            })
                            .AddTo(_disposables);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
