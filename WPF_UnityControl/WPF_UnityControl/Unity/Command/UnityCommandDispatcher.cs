using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.NetWork;

namespace WPF_UnityControl.Unity
{
    public class UnityCommandDispatcher
    {

        private readonly TcpClientController _tcpController;
        private readonly CommandGenerator _cmdGenerator;

        public UnityCommandDispatcher(TcpClientController tcpController)
        {
            _tcpController = tcpController;
            _cmdGenerator = new CommandGenerator();
        }

        public void SendCommand(CommandType cmd, string[]? parameters = null)
        {
            var cmdJson = _cmdGenerator.GenerateJsonCommand(cmd, parameters);
            _ = _tcpController.BeginSocketWrite(cmdJson);
        }
    }
}
