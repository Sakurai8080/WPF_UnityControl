using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Diagnostics;
using System.Reactive.Disposables;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;
using WPF_UnityControl.Models;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// アプリ操作のメインとなるUnity操作専用ViewModel
    /// </summary>
    public class UnityOperationControlViewModel : BindableBase, IDisposable
    {
        #region フィールド
        /// <summary> 購読管理オブジェクト </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> Unity操作インスタンス </summary>
        private UnityController _controller;

        /// <summary> イベント仲介オブジェクト </summary>
        private IEventAggregator _eventAggregator;

        /// <summary> Unityで変更するシーン名 </summary>
        private string _changeSceneName = "";
        #endregion
        #region プロパティ
        /// <summary> UnityScene一覧 </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; set; } = new ReactivePropertySlim<List<string>>();

        public ReactivePropertySlim<bool> IsSending { get; set; } = new ReactivePropertySlim<bool>(false);

        public ReactivePropertySlim<bool> OnConnected { get; set; } = new ReactivePropertySlim<bool>(false);

        /// <summary> Unity接続切り替え </summary>
        public ReactiveCommandSlim ConnectStateCommand { get; } = new ReactiveCommandSlim();

        /// <summary> シーン取得ボタン </summary>
        public ReactiveCommandSlim FetchSceneCommand { get; } = new ReactiveCommandSlim();

        /// <summary> シーン変更コマンド </summary>
        public ReactiveCommandSlim SceneChangeCommand { get; } = new ReactiveCommandSlim();

        /// <summmary>現在のヒエラルキー取得コマンド </summary>
        public ReactiveCommandSlim FetchSceneHierarchy { get; } = new ReactiveCommandSlim();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controller">Unity操作インスタンス(DIコンテナから自動注入)</param>
        public UnityOperationControlViewModel(UnityController controller, IEventAggregator eventAggregator)
        {
            _controller = controller;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<SceneNameChangedEvent>().Subscribe(name => _changeSceneName = name).AddTo(_disposables);


            ConnectStateCommand.Subscribe(_ => _controller.UnityConnetChange());
            FetchSceneCommand.Subscribe(async _ => await _controller.FetchUnityScene());
            SceneChangeCommand.Subscribe(async _ =>
                              {
                                  if (!string.IsNullOrEmpty(_changeSceneName))
                                  {
                                      await _controller.UnitySceneChenge(_changeSceneName);
                                  }
                              });

            FetchSceneHierarchy.Subscribe(async _ => await _controller.FetchUnityHierarchy());

            _controller.IsSending += (state) =>
            {
                IsSending.Value = state;
                Debug.WriteLine($"送信 >>>> {state}");
            };

            _controller.OnConnected += (state) =>
            {
                OnConnected.Value = state;
                Debug.WriteLine($"接続 >>>> {state}");
            };
        }
        #endregion

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
