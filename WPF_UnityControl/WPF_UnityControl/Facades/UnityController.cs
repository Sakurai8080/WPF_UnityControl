using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Facades
{
    public class UnityController
    {


        private UnityCommandDispatcher _unityDsp;

        public UnityController()
        {
            _unityDsp = new UnityCommandDispatcher();

        }

        /// <summary>
        /// Unity接続処理
        /// </summary>
        public void UnityConnetChange()
        {
            _ = _unityDsp.TCPController.ConnectToUnityAsync();
        }

        /// <summary>
        /// Unityシーン一覧取得
        /// </summary>
        public async Task<List<string>> FetchUnityScene()
        {
            await _unityDsp.BeginSendCommand(CommandType.SCENE_FETCH);
            await _unityDsp.WaitForSceneResponseAsync();

            return _unityDsp.SceneResponce.SceneList;
        }

        /// <summary>
        /// オブジェクト作成
        /// </summary>
        public void SetGameObjectPosition()
        {
            string[] prm = {"TestObject", "1", "2", "3" };
            _unityDsp.BeginSendCommand(CommandType.OBJECT_MOVE, prm);
        }
    }
}
