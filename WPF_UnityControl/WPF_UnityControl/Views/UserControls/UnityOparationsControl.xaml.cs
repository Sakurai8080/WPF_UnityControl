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

namespace WPF_UnityControl.Control
{
    /// <summary>
    /// UnityConnectTestControl.xaml の相互作用ロジック
    /// </summary>
    public partial class UnityOparationsControl : UserControl
    {

        private readonly TestConnectService _connect;

        public UnityOparationsControl()
        {
            InitializeComponent();

            _connect = new TestConnectService();
        }

        private async void btConnect_Click(object sender, RoutedEventArgs e)
        {
            await _connect.TestConnect();
        }

        private async void btSend_Click(object sender, RoutedEventArgs e)
        {
            //var sceneName = tbSceneName.Text;
            //await _client.SendMessageAsync($"LOAD_SCENE:{sceneName}");
        }

        private async void  btFetchScene_Click(object sender, RoutedEventArgs e)
        {
            //await _client.();
        }
    }
}
