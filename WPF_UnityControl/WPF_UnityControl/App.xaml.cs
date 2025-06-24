using System.Windows;
using WPF_UnityControl.Views;
using WPF_UnityControl.ViewModels;
using WPF_UnityControl.Control;
using WPF_UnityControl.Facades;
using WPF_UnityControl.Response;
using WPF_UnityControl.Unity;
using WPF_UnityControl.NetWork;
using WPF_UnityControl.Interface;

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
    /// コンテナへのサービス登録(シングルトン・ViewとViewModelの紐づけ)
    /// </summary>
    /// <param name="containerRegistry">コンテナ管理</param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IResponseData,SceneListResponse>("SceneRes");
        containerRegistry.RegisterSingleton<IResponseData, HierarchyResponse>("HieRarchyRes");
        containerRegistry.RegisterSingleton<IResponseData, ObjectDataResponse>("ObjectRes");

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

