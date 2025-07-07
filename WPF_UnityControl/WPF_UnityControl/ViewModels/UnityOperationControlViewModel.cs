using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// アプリ操作のメインとなるUnity操作専用ViewModel
    /// </summary>
    public class UnityOperationControlViewModel : BindableBase, IDisposable
    {
        #region フィールド
        /// <summary> 
        /// 購読管理オブジェクト (購読はこれを使用して破棄)
        /// </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> 
        /// Unity操作インスタンス 
        /// </summary>
        private UnityController _controller;

        /// <summary> 
        /// イベント通信管理
        /// </summary>
        private IEventAggregator _eventAggregator;

        /// <summary> 
        /// Unityで変更するシーン名 
        /// </summary>
        private string _changeSceneName = "";
        #endregion
        #region プロパティ
        /// <summary>
        /// UnityScene一覧 
        /// </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; set; } = new ReactivePropertySlim<List<string>>();

        /// <summary>
        /// 送信中フラグ
        /// </summary>
        public ReactivePropertySlim<bool> IsSending { get; set; } = new ReactivePropertySlim<bool>(false);

        /// <summary>
        /// Unity接続フラグ
        /// </summary>
        public ReactivePropertySlim<bool> OnConnected { get; set; } = new ReactivePropertySlim<bool>(false);

        /// <summary> 
        /// Unity接続切り替えボタン
        /// </summary>
        public ReactiveCommandSlim ConnectStateCommand { get; } = new ReactiveCommandSlim();

        /// <summary> 
        /// シーン取得ボタン 
        /// </summary>
        public ReactiveCommandSlim FetchSceneCommand { get; } = new ReactiveCommandSlim();

        /// <summary> 
        /// シーン変更コマンド
        /// </summary>
        public ReactiveCommandSlim SceneChangeCommand { get; } = new ReactiveCommandSlim();

        /// <summmary>
        /// 現在のヒエラルキー取得コマンド 
        /// </summary>
        public ReactiveCommandSlim FetchSceneHierarchy { get; } = new ReactiveCommandSlim();

        /// <summmary>
        /// 全値のクリアボタン
        /// </summary>
        public ReactiveCommandSlim ValueClearCommand { get; } = new ReactiveCommandSlim();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controller">Unity操作</param>
        /// <param name="eventAggregator">イベント通信管理</param>
        public UnityOperationControlViewModel(UnityController controller, IEventAggregator eventAggregator)
        {
            _controller = controller;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<SceneNameChangedEvent>()
                            .Subscribe(name =>
                            { // 選択シーン変更のイベント登録
                                _changeSceneName = name;
                            }).AddTo(_disposables);

            ConnectStateCommand.Subscribe(_ =>
                               { // 接続ボタン押下の購読
                                   _controller.UnityConnetChange();
                               }).AddTo(_disposables);

            FetchSceneCommand.Subscribe(async _ =>
                             { // シーン取得ボタン押下の購読
                                 await _controller.FetchUnityScene();
                             }).AddTo(_disposables);

            SceneChangeCommand.Subscribe(async _ =>
                              { // シーン変更ボタン押下の購読
                                  if (!string.IsNullOrEmpty(_changeSceneName))
                                      await _controller.UnitySceneChenge(_changeSceneName);
                              }).AddTo(_disposables);

            FetchSceneHierarchy.Subscribe(async _ =>
                               { // 選択中シーンのヒエラルキー取得ボタン押下の購読
                                   await _controller.FetchUnityHierarchy();
                               }).AddTo(_disposables);

            ValueClearCommand.Subscribe(_ =>
                             { // 値のクリアイベント発行
                                 _eventAggregator.GetEvent<ClearAllValuesEvent>().Publish();
                             }).AddTo(_disposables);

            _controller.OnCommandSending += (state) =>
            { // コマンド送信イベントの登録
                IsSending.Value = state;
            };

            _controller.OnUnityConnected += (s, e) =>
            { // 接続フラグ変更イベントの登録
                OnConnected.Value = e.IsConnected;
            };
        }
        #endregion

        /// <summary>
        /// 購読破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
