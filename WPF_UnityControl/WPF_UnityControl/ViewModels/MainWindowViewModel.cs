using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Control;

namespace WPF_UnityControl.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        /// <summary>
        /// 画面遷移に関する機能
        /// </summary>
        private readonly IRegionManager _regionManager;

        public ReactiveProperty<string> Title { get; } = new("Unity Control");
        

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager">画面の制御(Prismで自動注入)</param>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            // アプリ起動時にMainPageを指定
            _regionManager.RegisterViewWithRegion("ContentRegion", nameof(MainContentPage));
        }

    }
}
