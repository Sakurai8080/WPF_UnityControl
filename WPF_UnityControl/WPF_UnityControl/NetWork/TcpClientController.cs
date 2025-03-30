using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_UnityControl.NetWork
{
    /// <summary>
    /// TCP経由でデータの送受信を操作するクラス
    /// </summary>
    public class TcpClientController 
    {
        private readonly UnityTcpClient _tcp;

        public Action<string> OnJsonResponse = (json) => { };

        public TcpClientController()
        {
            _tcp = new UnityTcpClient();

            _tcp.OnReceived += json =>
            {
                OnJsonResponse(json);
            };
        }

        public async Task ConnectToUnityAsync()
        {
            await _tcp.ConnectAsync();
        }

        /// <summary>
        /// コマンドの送信   
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendCommandAsync(string message)
        {
            if (_tcp.Stream == null) return;

            byte[] data = Encoding.UTF8.GetBytes(message + "\n"); 　// コマンドをバイト配列に変換
            await _tcp.Stream.WriteAsync(data, 0, data.Length);
        }

    }
}
