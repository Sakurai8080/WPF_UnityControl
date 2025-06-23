using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Interface
{
    
    /// <summary>
    /// レスポンス用インターフェース
    /// </summary>
    public interface IResponseData
    {
        /// <summary>
        /// コマンド種類
        /// </summary>
        CommandType CommandType { get; }

        /// <summary>
        /// レスポンス実行
        /// </summary>
        /// <param name="json">返答データ</param>
        void Execute(string json);
    }
}
