using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;
using WPF_UnityControl.Models;

namespace WPF_UnityControl.ViewModels
{
    public class ObjectDetailControlViewModel
    {
        private IEventAggregator _eventAggregator;

        private readonly UnityController _controller;

        public ReactivePropertySlim<GameObjectModel> GameObjectData { get; set; } = new();

        public ReactiveCommandSlim TransformChangeCommand = new ReactiveCommandSlim();


        public ObjectDetailControlViewModel(UnityController controller, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _controller = controller;

            _eventAggregator.GetEvent<GameObjectDataFetchedEvent>()
                            .Subscribe(goData =>
                            {
                                GameObjectData.Value = goData;
                            });


            TransformChangeCommand.Subscribe(_ =>
                                  {
                                     // _controller.SetGameObjectTransform(transformInfo);
                                  });
        }
    }
}
