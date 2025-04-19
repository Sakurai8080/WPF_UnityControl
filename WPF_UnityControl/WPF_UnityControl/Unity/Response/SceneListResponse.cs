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
        /// レスポンス処理の実行
        /// </summary>
        /// <param name="json">シーン一覧Json</param>
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
        /// <param name="scenes">シーン一覧</param>
        public void ResponseToList(string[] scenes)
        {
            var sceneList = scenes?.ToList() ?? new();
            SceneList.Value = sceneList;
        }
    }
}
