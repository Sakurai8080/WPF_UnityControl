using Newtonsoft.Json;
using WPF_UnityControl.Base;
using WPF_UnityControl.Events;
using WPF_UnityControl.Interface;
using WPF_UnityControl.JsonPoco;
using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Response
{
    /// <summary>
    /// ヒエラルキーのレスポンスを処理するクラス
    /// </summary>
    public class HierarchyResponse : BaseResponse, IResponseData
    {
        #region プロパティ
        /// <summary>
        /// コマンドタイプ
        /// </summary>
        public CommandType CommandType => CommandType.FETCH_HIERARCHY;
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">イベント通信管理</param>
        public HierarchyResponse(IEventAggregator eventAggregator) : base(eventAggregator) { }
        #endregion

        /// <summary>
        /// レスポンス処理の実行
        /// </summary>
        /// <param name="json">受信したJson</param>
        public void Execute(string json)
        {
            // Jsonを配列に変換
            var hierarchyJson = JsonConvert.DeserializeObject<string[]>(json);

            if (hierarchyJson?.Length >= 1)
            { // ノードに変換
                var nodes = JsonConvert.DeserializeObject<List<HierarchyNode>>(hierarchyJson[0]);
                if (nodes != null)
                { // ヒエラルキー取得イベント発行
                    _eventAggregator.GetEvent<HierarchyFetchedEvent>().Publish(nodes);
                }
            }

        }
    }
}
