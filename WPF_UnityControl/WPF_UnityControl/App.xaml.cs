using System.Configuration;
using System.Data;
using Prism.Unity;
using Prism.Ioc;
using System.Windows;
using WPF_UnityControl.Views;
using WPF_UnityControl.ViewModels;
using WPF_UnityControl.Control;
using WPF_UnityControl.Facades;
using WPF_UnityControl.Response;
using WPF_UnityControl.Unity;
using WPF_UnityControl.NetWork;
using System.Net.Sockets;

namespace WPF_UnityControl;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    /// <summary>
    /// コンテナへの型登録。ViewとViewModelの紐づけ
    /// </summary>
    /// <param name="containerRegistry"></param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<SceneListResponse>();
        containerRegistry.RegisterSingleton<HierarchyResponse>();
        containerRegistry.RegisterSingleton<ObjectDataResponse>();
        containerRegistry.RegisterSingleton<ResponseController>();
        containerRegistry.RegisterSingleton<TcpClientController>();
        containerRegistry.RegisterSingleton<UnityCommandDispatcher>();

        containerRegistry.RegisterSingleton<UnityController>();
        containerRegistry.RegisterForNavigation<MainContentPage>();
        containerRegistry.RegisterForNavigation<UnityOperationControl, UnityOperationControlViewModel>();
        containerRegistry.RegisterForNavigation<SceneListControl, SceneListControlViewModel>();
        containerRegistry.RegisterForNavigation<HierarchyControl, HierarchyControlViewModel>();
        containerRegistry.RegisterForNavigation<ObjectDetailControl, ObjectDetailControlViewModel>();
        containerRegistry.RegisterForNavigation<LogControl, LogControlViewModel>();
    }
}

