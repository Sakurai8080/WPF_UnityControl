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
        /// コマンドタイプからUnity送信用コマンド(Json)を作成 (取得用 : パラメータなし)
        /// </summary>
        /// <param name="cmd">コマンドタイプ</param>
        /// <returns>JSONファイル文字列</returns>
        public string GenerateJsonCommand(CommandType cmd)
        {
            var commandData = new
            {
                Command = cmd.ToString()
            };
            return JsonConvert.SerializeObject(commandData);
        }

        /// <summary> 
        /// コマンドタイプからUnity送信用コマンド(Json)を作成 (取得用 : パラメータあり)
        /// </summary> 
        /// <param name="cmd">コマンドタイプ</param>
        /// <param name="parameters">コマンドに応じたパラメータ</param>
        /// <returns>JSONファイル文字列</returns>
        public string GenerateJsonCommand(CommandType cmd, object parameter)
        {
            var commandData = new JsonCommand(cmd.ToString(), parameter);
            return JsonConvert.SerializeObject(commandData);
        }
    }
}
