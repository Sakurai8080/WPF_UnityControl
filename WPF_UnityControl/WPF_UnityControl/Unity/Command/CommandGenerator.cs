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
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GenerateJsonCommand(CommandType cmd, string[]? parameters =null)
        {
            //Json作成
            var commandData = new
            {
                Command = cmd.ToString(),
                Parameters = parameters ?? new string[0]
            };

            return JsonConvert.SerializeObject(commandData);
        }
    }
}
