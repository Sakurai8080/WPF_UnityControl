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
using WPF_UnityControl.ViewModels;

namespace WPF_UnityControl.Control
{
    /// <summary>
    /// HierarchyControl.xaml の相互作用ロジック
    /// </summary>
    public partial class HierarchyControl : UserControl
    {
        public HierarchyControl()
        {
            InitializeComponent();
        }

        private void hierarchy_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selecte = e.NewValue;
            if (DataContext is HierarchyControlViewModel vm && e.NewValue != null)
            {
                var select = e.NewValue.GetType();
                vm.SelectedName.Value = select.Name.ToString();
            }
        }
    }
}
