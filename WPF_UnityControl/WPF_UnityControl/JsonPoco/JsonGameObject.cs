using Newtonsoft.Json;

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
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// オブジェクトタグ
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// オブジェクトレイヤー
        /// </summary>
        [JsonProperty("layer")]
        public string Layer { get; set; }

        /// <summary>
        /// アクティブフラグ
        /// </summary>
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// トランスフォームデータ
        /// </summary>
        [JsonProperty("transform")]
        public JsonTransform Transform { get; set; }
    }

    /// <summary>
    /// トランスフォームデータ
    /// </summary>
    public class JsonTransform
    {
        /// <summary>
        /// ポジション
        /// </summary>
        [JsonProperty("position")]
        public JsonVector3 Position { get; set; }

        /// <summary>
        /// 回転
        /// </summary>
        [JsonProperty("rotation")]
        public JsonVector3 Rotation { get; set; }

        /// <summary>
        /// サイズ
        /// </summary>
        [JsonProperty("scale")]
        public JsonVector3 Scale { get; set; }
    }

    /// <summary>
    /// Vector3データ
    /// </summary>
    public class JsonVector3
    {
        /// <summary>
        /// Vector3 X
        /// </summary>
        [JsonProperty("x")]
        public float X { get; set; }

        /// <summary>
        /// Vector3 Y
        /// </summary>
        [JsonProperty("y")]
        public float Y { get; set; }

        /// <summary>
        /// Vector3 Z
        /// </summary>
        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
