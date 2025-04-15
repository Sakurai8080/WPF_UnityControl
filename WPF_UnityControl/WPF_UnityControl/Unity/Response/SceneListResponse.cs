using Newtonsoft.Json;
using Reactive.Bindings;
using WPF_UnityControl.Interface;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// シーン一覧専用レスポンスクラス
    /// </summary>
    public class SceneListResponse : IResponseData
    {
        #region プロパティ
        /// <summary> Unityシーン一覧 </summary>
        public ReactivePropertySlim<List<string>> SceneList { get; } = new ReactivePropertySlim< List<string>>(new List<string>());
        #endregion

        /// <summary>
        /// Jsonファイルを基に処理を実行
        /// </summary>
        /// <param name="json">Unityから受け取ったJsonファイル</param>
        public void Execute(string json)
        {
            var scenes = JsonConvert.DeserializeObject<string[]>(json);
            if (scenes?.Length >= 1)
            {
                ResponseToList(scenes);
            }
        }

        /// <summary>
        /// Jsonファイルのシーン一覧をコレクションに格納
        /// </summary>
        /// <param name="scenes"></param>
        public void ResponseToList(string[] scenes)
        {
            var sceneList = scenes?.ToList() ?? new();
            SceneList.Value = sceneList;
        }
    }
}
