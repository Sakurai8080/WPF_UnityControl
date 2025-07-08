using System.Windows.Controls;

namespace WPF_UnityControl.Control
{
    /// <summary>
    /// LogControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
        }

        private void TextBlock_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            logScrollViewer?.ScrollToEnd();
        }
    }
}
