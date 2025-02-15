using System.Configuration;
using System.Data;
using Prism.Unity;
using Prism.Ioc;
using System.Windows;

namespace WPF_UnityControl;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // DIコンテナに型追加
    }

    protected override Window CreateShell()
    {
        var window = Container.Resolve<MainWindow>();
        return window;
    }
}

