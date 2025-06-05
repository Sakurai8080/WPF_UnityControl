using Newtonsoft.Json;

namespace WPF_UnityControl
{
    /// <summary>
    /// コマンド作成用JsonPOCOクラス
    /// </summary>
    public class JsonCommand
    {
        [JsonProperty("CommandType")]
        public string Command { get; set; }

        [JsonProperty("Parameters")]
        public object Parameters { get; set; }

        public JsonCommand(string command, object parameters)
        {
            Command = command;
            Parameters = parameters;
        }
    }
}
