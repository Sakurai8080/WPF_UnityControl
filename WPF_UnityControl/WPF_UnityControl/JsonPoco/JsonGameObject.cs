using Newtonsoft.Json;

namespace WPF_UnityControl.JsonPoco
{
    public class JsonGameObject
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }

        [JsonProperty("Layer")]
        public string Layer { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Transform")]
        public JsonTransform Transform { get; set; }
    }

    public class JsonTransform
    {
        [JsonProperty("Position")]
        public JsonVector3 Position { get; set; }

        [JsonProperty("Rotation")]
        public JsonVector3 Rotation { get; set; }

        [JsonProperty("Scale")]
        public JsonVector3 Scale { get; set; }
    }

    public class JsonVector3
    {
        [JsonProperty("X")]
        public float X { get; set; }

        [JsonProperty("Y")]
        public float Y { get; set; }
        [JsonProperty("Z")]
        public float Z { get; set; }
    }
}
