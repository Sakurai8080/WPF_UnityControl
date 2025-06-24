using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ヒエラルキーTree表示用ViewModel
    /// </summary>
    public class HierarchyControlViewModel : IDisposable
    {
        #region フィールド
        /// <summary> 
        /// 購読管理オブジェクト 
        /// </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary> 
        /// イベント仲介オブジェクト 
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Unityコントローラーインスタンス
        /// </summary>
        private readonly UnityController _controller;
        #endregion
        #region プロパティ
        /// <summary>
        /// ヒエラルキー表示データ
        /// </summary>
        public ReactivePropertySlim<List<HierarchyNode>> HierarchyTree { get; } = new ReactivePropertySlim<List<HierarchyNode>>();

        /// <summary>
        /// 選択中のゲームオブジェクト
        /// </summary>
        public ReactivePropertySlim<string> SelectedName { get; } = new ReactivePropertySlim<string>();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント通信管理</param>
        /// <param name="controller">Unity操作</param>
        public HierarchyControlViewModel(IEventAggregator eventAggregator, UnityController controller)
        {
            _eventAggregator = eventAggregator;
            _controller = controller;

            _eventAggregator.GetEvent<HierarchyFetchedEvent>()
                            .Subscribe(nodes =>
                            { // ヒエラルキー取得イベント購読
                                HierarchyTree.Value = nodes;
                            })
                            .AddTo(_disposables);

            SelectedName.Subscribe(async name =>
                        { // ヒエラルキーを選択したらゲームオブジェクトデータを取得
                            await _controller.FetchObjectData(name);
                        }).AddTo(_disposables);
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
