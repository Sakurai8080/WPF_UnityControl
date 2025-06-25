using Reactive.Bindings;

namespace WPF_UnityControl.Models
{
    /// <summary>
    /// Vector3 UI表示用モデルクラス
    /// </summary>
    public class Vector3Model
    {
        /// <summary>
        /// Vector3 X
        /// </summary>
        public ReactivePropertySlim<float> X { get; set; } = new ReactivePropertySlim<float>();

        /// <summary>
        /// Vector3 Y
        /// </summary>
        public ReactivePropertySlim<float> Y { get; set; } = new ReactivePropertySlim<float>();

        /// <summary>
        /// Vector3 Z
        /// </summary>
        public ReactivePropertySlim<float> Z { get; set; } = new ReactivePropertySlim<float>();
    }
}
