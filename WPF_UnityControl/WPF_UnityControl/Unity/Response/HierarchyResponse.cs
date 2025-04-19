using Newtonsoft.Json;
using Reactive.Bindings;
using WPF_UnityControl.Base;
using WPF_UnityControl.Events;
using WPF_UnityControl.Interface;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// ヒエラルキーのレスポンスを処理するクラス
    /// </summary>
    public class HierarchyResponse : BaseResponse, IResponseData
    {

        public HierarchyResponse(IEventAggregator eventAggregator) : base(eventAggregator) { }

        /// <summary>
        /// レスポンス処理の実行
        /// </summary>
        /// <param name="json"></param>
        public void Execute(string json)
        {
            // Jsonを配列に変換
            var hierarchyJson = JsonConvert.DeserializeObject<string[]>(json);

            if (hierarchyJson?.Length >= 1)
            { // ノードに変換
                var nodes = JsonConvert.DeserializeObject<List<HierarchyNode>>(hierarchyJson[0]);
                if (nodes != null)
                {
                    _eventAggregator.GetEvent<HierarchyFetchedEvent>().Publish(nodes);
                }
            }

        }
    }
}
