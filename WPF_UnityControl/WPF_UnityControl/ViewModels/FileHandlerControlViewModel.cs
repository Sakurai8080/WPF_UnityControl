using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using WPF_UnityControl.Models;
using WPF_UnityControl.Service;

namespace WPF_UnityControl.ViewModels
{
    /// <summary>
    /// ゲームオブジェクトのファイル操作ViewModel
    /// </summary>
    public class FileHandlerControlViewModel : IDisposable
    {
        #region フィールド
        /// <summary>
        /// ゲームオブジェクトデータ共有クラス
        /// </summary>
        private readonly GameObjectDataStore _objectData;

        /// <summary> 
        /// 購読管理オブジェクト 
        /// </summary>
        private readonly CompositeDisposable _disposables = new();
        #endregion
        #region プロパティ
        /// <summary>
        /// ゲームオブジェクトデータ保存ボタン専用コマンド
        /// </summary>
        public ReactiveCommandSlim ObjectSaveCommand { get; } = new();

        /// <summary>
        /// ゲームオブジェクトデータ読込ボタン専用コマンド
        /// </summary>
        public ReactiveCommandSlim ObjectLoadCommand { get; } = new();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dataStore">データ共有クラス</param>
        public FileHandlerControlViewModel(GameObjectDataStore dataStore)
        {
            _objectData = dataStore;

            var goExporter = new GameObjectFileService();

            ObjectSaveCommand.Subscribe(_ =>
            { // 保存ボタン押下
                var data = _objectData.CurrentGameObjectData.Value;
                goExporter.SaveAsJson(data, $@"C:\UnityFile\{data.Name}Data.json");
            }).AddTo(_disposables);

            ObjectLoadCommand.Subscribe(_ =>
            {
                var goData = goExporter.LoadGameObjectJson();
                if (goData != null)
                {
                    _objectData.CurrentGameObjectData.Value = goData;
                }
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