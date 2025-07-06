using System.Text.Json.Serialization;

namespace WPF_UnityControl.JsonPoco
{
    /// <summary>
    /// ゲームオブジェクトデータ
    /// </summary>
    public class JsonGameObject
    {
        /// <summary>
        /// ゲームオブジェクト名
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// オブジェクトタグ
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        /// <summary>
        /// オブジェクトレイヤー
        /// </summary>
        [JsonPropertyName("layer")]
        public string? Layer { get; set; }

        /// <summary>
        /// アクティブフラグ
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// トランスフォームデータ
        /// </summary>
        [JsonPropertyName("transform")]
        public JsonTransform? Transform { get; set; }
    }

    /// <summary>
    /// トランスフォームデータ
    /// </summary>
    public class JsonTransform
    {
        /// <summary>
        /// ポジション
        /// </summary>
        [JsonPropertyName("position")]
        public JsonVector3? Position { get; set; }

        /// <summary>
        /// 回転
        /// </summary>
        [JsonPropertyName("rotation")]
        public JsonVector3? Rotation { get; set; }

        /// <summary>
        /// サイズ
        /// </summary>
        [JsonPropertyName("scale")]
        public JsonVector3? Scale { get; set; }
    }

    /// <summary>
    /// Vector3データ
    /// </summary>
    public class JsonVector3
    {
        /// <summary>
        /// Vector3 X
        /// </summary>
        [JsonPropertyName("x")]
        public float X { get; set; }

        /// <summary>
        /// Vector3 Y
        /// </summary>
        [JsonPropertyName("y")]
        public float Y { get; set; }

        /// <summary>
        /// Vector3 Z
        /// </summary>
        [JsonPropertyName("z")]
        public float Z { get; set; }
    }
}
