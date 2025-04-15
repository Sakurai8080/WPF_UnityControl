using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.Events
{
    /// <summary> シーン一覧取得時の発行イベント </summary>
    public class SceneListUpdateEvent : PubSubEvent<List<string>>{}
    public class SceneNameChangedEvent : PubSubEvent<string> { }

    public class HierarchyFetchedEvent : PubSubEvent<List<HierarchyNode>> { }
}
