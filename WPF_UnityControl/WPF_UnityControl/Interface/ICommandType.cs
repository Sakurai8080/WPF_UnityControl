using WPF_UnityControl.Unity;

namespace WPF_UnityControl.Interface
{
    /// <summary>
    /// レスポンスクラスのインターフェース
    /// </summary>
    public interface ICommandType
    {
        /// <summary>
        /// コマンド種類
        /// </summary>
        CommandType CommandType { get; }
    }
}
