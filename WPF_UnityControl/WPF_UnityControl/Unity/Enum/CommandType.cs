namespace WPF_UnityControl.Unity
{
    /// <summary>
    /// Unityとやり取りするコマンド列挙 
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// シーン変更コマンド
        /// </summary>
        SCENE_CHANGE = 0,

        /// <summary>
        /// シーン取得コマンド
        /// </summary>
        SCENE_FETCH = 1,

        /// <summary>
        /// ヒエラルキー取得コマンド
        /// </summary>
        FETCH_HIERARCHY = 2,

        /// <summary>
        /// ゲームオブジェクトデータ取得コマンド
        /// </summary>
        GET_OBJECT_DATA = 3,

        /// <summary>
        /// ゲームオブジェクト設定コマンド
        /// </summary>
        SET_OBJECT_DATA = 4,
    }
}
