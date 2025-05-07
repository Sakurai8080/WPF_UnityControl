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
using WPF_UnityControl.JsonPoco;
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

        /// <summary>
        /// 選択したオブジェクトを取り出すイベント
        /// </summary>
        private void hierarchy_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DataContext is HierarchyControlViewModel vm && e.NewValue != null)
            {
                if (e.NewValue is HierarchyNode item)
                {
                   vm.SelectedName.Value = item.Name;
                }
            }
        }
    }
}
