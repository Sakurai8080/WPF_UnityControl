using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl.Unity
{
    public class SceneCommandResponse
    {

        private string _responseData = "";

        private List<string> _sceneList = new List<string>();

        public string ResponseData => _responseData;

        public List<string> SceneList => _sceneList;



        public SceneCommandResponse(string response)
        {
            _responseData = response;
            if (_responseData.Length >= 1)
            {
                ResponseToList(_responseData);
            }
        }


        public void ResponseToList(string response)
        {
            string[] sceneNames = JsonConvert.DeserializeObject<string[]>(response);
            if (sceneNames.Count() >= 1)
            {
                _sceneList.AddRange(sceneNames);
            }
        }
    }
}
