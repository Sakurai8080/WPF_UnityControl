
namespace WPF_UnityControl.Models
{
    /// <summary>
    /// トランスフォームUI表示用モデルクラス
    /// </summary>
    public class TransformModel
    {
        /// <summary>
        /// ゲームオブジェクトPosition
        /// </summary>
        public Vector3Model? Position { get; set; } = new Vector3Model();

        /// <summary>
        /// ゲームオブジェクトRotation
        /// </summary>
        public Vector3Model? Rotation { get; set; } = new Vector3Model();

        /// <summary>
        /// ゲームオブジェクトScale
        /// </summary>
        public Vector3Model? Scale { get; set; } = new Vector3Model();
    }
}
