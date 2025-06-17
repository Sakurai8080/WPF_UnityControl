using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.Events
{
    /// <summary>
    /// シーン一覧更新通知イベント
    /// </summary>
    public class SceneListUpdateEvent : PubSubEvent<List<string>>{}

    /// <summary>
    /// 選択中のシーン取得通知イベント
    /// </summary>
    public class SceneNameChangedEvent : PubSubEvent<string> { }

    /// <summary>
    /// ゲームオブジェクトのヒエラルキー取得通知イベント
    /// </summary>
    public class HierarchyFetchedEvent : PubSubEvent<List<HierarchyNode>> { }
}
