namespace WPF_UnityControl.Models
{
    /// <summary>
    /// UI表示用モデルデータ
    /// </summary>
    public class GameObjectModel
    {
        /// <summary>
        /// オブジェクト名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// オブジェクトタグ
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// オブジェクトレイヤー
        /// </summary>
        public string? Layer { get; set; }

        /// <summary>
        /// アクティブフラグ
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// トランスフォームデータ
        /// </summary>
        public TransformModel? Transform { get; set; }
    }
}
