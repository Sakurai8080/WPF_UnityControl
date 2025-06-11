using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Facades;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ログ情報ViewModel
    /// </summary>
    public class LogControlViewModel
    {
        private UnityController _controller;

        public ReactiveProperty<string> Log { get; } = new ReactiveProperty<string>();

        public LogControlViewModel(UnityController controller)
        {
            _controller = controller;

            _controller.OnUnityConnected += (msg) =>
            {
                Log.Value += msg;
            };

            _controller.OnResponseReceive += (msg) =>
            {
                Log.Value += msg;
            };
        }
    }
}
