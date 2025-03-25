using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {
        private UnityCommandDispatcher _unityDsp;

        public UnityController()
        {
            _unityDsp = new UnityCommandDispatcher();
        }

        public void UnityConnetChange()
        {
            _ = _unityDsp.TCPController.ConnectToUnityAsync();
        }

        private void SetObjectPosition()
        {
            string[] prm = { "x : 1", "y : 2", " z : 3" };
            //_unityDsp.BeginSendCommand(CommandType.OBJECT_MOVE, prm);
        }
    }
}
