using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_UnityControl.NetWork
{
    public class TcpClientController
    {
        private readonly UnityTcpClient _tcp;

        public TcpClientController(UnityTcpClient tcp)
        {
            _tcp = tcp;
        }

        public async Task BeginSocketWrite(string cmd)
        {
            if (_tcp == null || cmd.Length < 1) 
                return;

            try
            {
                await _tcp.SendCommandAsync(cmd);
            }
            catch(SocketException ex)
            {
                MessageBox.Show($"サーバーへの送信中にエラーが発生しました : {ex.Message} \n 接続を確認してください。");
            }
        }
    }
}
