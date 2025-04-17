namespace WPF_UnityControl.JsonPoco
{
    /// <summary>
    /// ヒエラルキーのPOCOクラス
    /// </summary>
    public class HierarchyNode
    {
        public string Name { get; set; }
        public List<HierarchyNode> Children { get; set; } = new List<HierarchyNode>();

    }
}
