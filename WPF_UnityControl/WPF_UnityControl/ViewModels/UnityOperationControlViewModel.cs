﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Facades;
using WPF_UnityControl.NetWork;

namespace WPF_UnityControl.ViewModels
{
    public class UnityOperationControlViewModel : BindableBase
    {
        private UnityController _controller;

        /// <summary> Unity接続切り替え </summary>
        public ReactiveCommandSlim ConnectStateCommand { get; } = new ReactiveCommandSlim();

        /// <summary> シーン取得ボタン </summary>
        public ReactiveCommandSlim FetchSceneCommand { get; } = new ReactiveCommandSlim();

        /// <summary> ゲームオブジェクト移動 </summary>
        public ReactiveCommandSlim SetGameObjectCommand { get; } = new ReactiveCommandSlim();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controller">Unity操作インスタンス(DIコンテナから自動注入)</param>
        public UnityOperationControlViewModel(UnityController controller)
        {
            _controller = controller;
            ConnectStateCommand.Subscribe(_ => _controller.UnityConnetChange());
            SetGameObjectCommand.Subscribe(_ => _controller.SetGameObjectPosition());
        }
    }
}
