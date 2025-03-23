using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl
{
    /// <summary>
    /// コマンド作成用JsonPOCOクラス
    /// </summary>
    public class JsonCommand
    {
        [JsonProperty("Command")]
        public string Command { get; set; }

        [JsonProperty("Parameters")]
        public string[] Parameters { get; set; }

        public JsonCommand(string command, string[] parameters)
        {
            Command = command;
            Parameters = parameters;
        }
    }
}
