using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Events;

namespace WPF_UnityControl.ViewModels
{
    public class SceneListControlViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        public ReactivePropertySlim<List<string>> SceneList { get; } = new ReactivePropertySlim<List<string>>();
        
        public SceneListControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<SceneListUpdateEvent>().Subscribe(sceneList =>
            {
                SceneList.Value = sceneList;
            });
        }
    }
}
