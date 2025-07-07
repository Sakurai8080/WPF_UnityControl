using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using WPF_UnityControl.Events;
using WPF_UnityControl.Facades;
using WPF_UnityControl.Models;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ゲームオブジェクトデータ表示用ViewModel
    /// </summary>
    public class ObjectDetailControlViewModel
    {
        #region フィールド
        /// <summary> 
        /// 購読管理オブジェクト 
        /// </summary>
        private readonly CompositeDisposable _disposables = new();

        /// <summary>
        /// イベント通信管理
        /// </summary>
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Unity操作インスタンス
        /// </summary>
        private readonly UnityController _controller;
        #endregion
        #region プロパティ
        /// <summary>
        /// ゲームオブジェトのデータを保持するモデルクラス
        /// </summary>
        public ReactivePropertySlim<GameObjectModel> GameObjectData { get;}

        /// <summary>
        /// ゲームオブジェクトの値変更ボタン
        /// </summary>
        public ReactiveCommandSlim ObjectDataApplyCommand { get; } = new ReactiveCommandSlim();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controller">Unity操作</param>
        /// <param name="eventAggregator">イベント通信管理</param>
        public ObjectDetailControlViewModel(UnityController controller, IEventAggregator eventAggregator, GameObjectDataStore dataStore)
        {
            _eventAggregator = eventAggregator;
            _controller = controller;

            GameObjectData = dataStore.CurrentGameObjectData;

            _eventAggregator.GetEvent<GameObjectDataFetchedEvent>()
                            .Subscribe(goData =>
                            { // ゲームオブジェクトデータ取得イベント購読
                                GameObjectData.Value = goData;
                            }).AddTo(_disposables);

            ObjectDataApplyCommand.Subscribe(_ =>
                                  { // ゲームオブジェクトのデータ適用ボタン購読
                                      _controller.SetGameObjectData(GameObjectData.Value);
                                  }).AddTo(_disposables);

            _eventAggregator.GetEvent<ClearAllValuesEvent>()
                            .Subscribe(ClearValues).AddTo(_disposables); // 値クリアイベント購読
        }
        #endregion

        /// <summary>
        /// 値のクリア
        /// </summary>
        private void ClearValues()
        {
            GameObjectData.Value = null;
        }

        /// <summary>
        /// 購読破棄
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}