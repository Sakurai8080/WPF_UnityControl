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

        public ReactivePropertySlim<string> PosX = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> PosY = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> PosZ = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> RotX = new ReactivePropertySlim<string >();
        public ReactivePropertySlim<string> RotY = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> RotZ = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ScaX = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ScaY = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ScaZ = new ReactivePropertySlim<string>();

        public ReactiveCommandSlim TransformChangeCommand = new ReactiveCommandSlim();


        public ObjectDetailControlViewModel(UnityController controller, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _controller = controller;

            TransformChangeCommand.Subscribe(_ =>
                                  {
                                      var transformInfo = new TransformModel
                                      {
                                          ObjectPosX = PosX.Value,
                                          ObjectPosY = PosX.Value,
                                          ObjectPosZ = PosX.Value,
                                          ObjectRotX = PosX.Value,
                                          ObjectRotY = PosX.Value,
                                          ObjectRotZ = PosX.Value,
                                          ObjectScaX = PosX.Value,
                                          ObjectScaY = PosX.Value,
                                          ObjectScaZ = PosX.Value,

                                      };
                                      _controller.SetGameObjectTransform(transformInfo);
                                  });
        }
    }
}
