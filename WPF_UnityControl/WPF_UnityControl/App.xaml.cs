﻿using System.Configuration;
using System.Data;
using Prism.Unity;
using Prism.Ioc;
using System.Windows;
using WPF_UnityControl.Views;
using WPF_UnityControl.ViewModels;
using WPF_UnityControl.Control;
using WPF_UnityControl.Facades;

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
        containerRegistry.RegisterSingleton<UnityController>();
        containerRegistry.RegisterForNavigation<MainContentPage>();
        containerRegistry.RegisterForNavigation<UnityOperationControl, UnityOperationControlViewModel>();
        containerRegistry.RegisterForNavigation<SceneListControl, SceneListControlViewModel>();
    }
}

