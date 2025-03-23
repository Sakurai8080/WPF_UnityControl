using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_UnityControl.NetWork;
using WPF_UnityControl.Test;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Control
{
    /// <summary>
    /// UnityConnectTestControl.xaml の相互作用ロジック
    /// </summary>
    public partial class UnityOparationsControl : UserControl
    {

        private readonly UnityTcpClient _connect;
        private readonly UnityCommandDispatcher _unityDsp;


        public UnityOparationsControl()
        {
            InitializeComponent();

            _connect = new UnityTcpClient();
            _unityDsp = new UnityCommandDispatcher(new TcpClientController(_connect));
        }

        private async void btConnect_Click(object sender, RoutedEventArgs e)
        {
            await _connect.ConnectAsync();
        }

        private async void btSend_Click(object sender, RoutedEventArgs e)
        {
            string[] prm = { "x : 1", "y : 2", " z : 3" };
            _unityDsp.BeginSendCommand(CommandType.OBJECT_MOVE, prm);
        }

        private async void  btFetchScene_Click(object sender, RoutedEventArgs e)
        {
            //await _client.();
        }
    }
}
