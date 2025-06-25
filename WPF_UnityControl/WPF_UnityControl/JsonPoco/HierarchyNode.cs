namespace WPF_UnityControl.JsonPoco
{
    /// <summary>
    /// ヒエラルキーのPOCOクラス
    /// </summary>
    public class HierarchyNode
    {
        /// <summary>
        /// ゲームオブジェクト名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ヒエラルキーの子階層
        /// </summary>
        public List<HierarchyNode> Children { get; set; } = new List<HierarchyNode>();

    }
}
