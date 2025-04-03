﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
        /// <summary> 購読管理オブジェクト </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> Unity操作インスタンス </summary>
        private UnityController _controller;

        /// <summary> イベント仲介オブジェクト </summary>
        private IEventAggregator _eventAggregator;
        #endregion
        #region プロパティ
        /// <summary> UnityScene一覧 </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; set; } = new ReactivePropertySlim<List<string>>();

        /// <summary> Unity接続切り替え </summary>
        public ReactiveCommandSlim ConnectStateCommand { get; } = new ReactiveCommandSlim();

        /// <summary> シーン取得ボタン </summary>
        public ReactiveCommandSlim FetchSceneCommand { get; } = new ReactiveCommandSlim();

        /// <summary> ゲームオブジェクト移動 </summary>
        public ReactiveCommandSlim SetGameObjectCommand { get; } = new ReactiveCommandSlim();
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

            _controller.SceneResponse.SceneList
                                     .Subscribe(list =>
                                     { // シーン一覧変更を購読
                                           _eventAggregator?.GetEvent<SceneListUpdateEvent>().Publish(list);
                                     })
                                     .AddTo(_disposables);
                                                   

            ConnectStateCommand.Subscribe(_ => _controller.UnityConnetChange());
            FetchSceneCommand.Subscribe(async _ => await _controller.FetchUnityScene());
            SetGameObjectCommand.Subscribe(_ => _controller.SetGameObjectPosition());
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
