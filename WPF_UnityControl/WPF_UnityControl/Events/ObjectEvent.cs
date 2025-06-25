using WPF_UnityControl.Models;

namespace WPF_UnityControl.Events
{
    /// <summary>
    /// ゲームオブジェクトのデータ取得通知用イベント
    /// </summary>
    public class GameObjectDataFetchedEvent : PubSubEvent<GameObjectModel> { }
}
