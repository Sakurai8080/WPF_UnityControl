using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using WPF_UnityControl.Facades;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ログ情報ViewModel
    /// </summary>
    public class LogControlViewModel : IDisposable
    {
        #region フィールド
        /// <summary> 
        /// 購読管理オブジェクト 
        /// </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary>
        /// Unity操作インスタンス
        /// </summary>
        private UnityController _controller;
        #endregion
        #region プロパティ
        /// <summary>
        /// ログ表示用プロパティ
        /// </summary>
        public ReactiveProperty<string> Log { get; set; } = new ReactiveProperty<string>();

        /// <summary>
        /// ログクリアボタン用コマンド
        /// </summary>
        public ReactiveCommandSlim LogClear { get; } = new ReactiveCommandSlim();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controller">Unity操作インスタンス : DI</param>
        public LogControlViewModel(UnityController controller)
        {
            _controller = controller;

            _controller.OnUnityConnected += (s, e) =>
            { // Unity接続メッセージイベント登録
                Log.Value += $"{e.Message}\r\n";
            };

            _controller.OnResponseReceive += (msg) =>
            { // レスポンス取得メッセージイベント登録
                Log.Value += msg;
            };

            //ログクリアボタンで文字列を空にする
            LogClear.Subscribe(_ => Log.Value = "").AddTo(_disposables);
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
