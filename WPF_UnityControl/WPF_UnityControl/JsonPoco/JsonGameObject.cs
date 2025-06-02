using Newtonsoft.Json;

namespace WPF_UnityControl.JsonPoco
{
    public class JsonGameObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("layer")]
        public string Layer { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("transform")]
        public JsonTransform Transform { get; set; }
    }

    public class JsonTransform
    {
        [JsonProperty("position")]
        public JsonVector3 Position { get; set; }

        [JsonProperty("rotation")]
        public JsonVector3 Rotation { get; set; }

        [JsonProperty("scale")]
        public JsonVector3 Scale { get; set; }
    }

    public class JsonVector3
    {
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }
        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
