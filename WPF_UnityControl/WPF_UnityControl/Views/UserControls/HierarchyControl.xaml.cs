using System.Windows;
using System.Windows.Controls;
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
