using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WPF_UnityControl.Unity
{
    public class CommandGenerator
    {
        /// <summary>
        /// コマンドタイプからUnity送信用コマンド(Json)を作成
        /// </summary>
        /// <param name="cmd">コマンドタイプ</param>
        /// <param name="parameters">コマンドに応じたパラメータ</param>
        /// <returns>JSONファイル文字列</returns>
        public string GenerateJsonCommand(CommandType cmd, string[]? parameters =null)
        {
            var commandData = new
            { // JSONの作成
                Command = cmd.ToString(),
                Parameters = parameters ?? new string[0]
            };

            return JsonConvert.SerializeObject(commandData);
        }
    }
}
