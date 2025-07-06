using Reactive.Bindings;

namespace WPF_UnityControl.Models
{
    /// <summary>
    /// ゲームオブジェクトデータの状態保持クラス
    /// </summary>
    public class GameObjectDataStore
    {
        /// <summary>
        /// ゲームオブジェクトモデル
        /// </summary>
        public ReactivePropertySlim<GameObjectModel> CurrentGameObjectData { get; } = new();
    }
}
