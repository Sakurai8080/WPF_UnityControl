using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.NetWork;

namespace WPF_UnityControl.Test
{
    public class TestConnectService
    {

        UnityTcpClient _unity = new UnityTcpClient();

        public async Task TestConnect()
        {
            await _unity.ConnectAsync();
        }
    }
}
