using Newtonsoft.Json;

namespace WPF_UnityControl
{
    /// <summary>
    /// コマンド作成用JsonPOCOクラス
    /// </summary>
    public class JsonCommand
    {
        #region プロパティ
        /// <summary>
        /// コマンドタイプ
        /// </summary>
        [JsonProperty("CommandType")]
        public string Command { get; set; }

        /// <summary>
        /// 設定する値
        /// </summary>
        [JsonProperty("Parameters")]
        public object Parameters { get; set; }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="command">コマンドタイプ</param>
        /// <param name="parameters">値</param>
        public JsonCommand(string command, object parameters)
        {
            Command = command;
            Parameters = parameters;
        }
        #endregion
    }
}
