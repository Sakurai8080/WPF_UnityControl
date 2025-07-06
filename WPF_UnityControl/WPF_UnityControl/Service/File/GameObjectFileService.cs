using System.Text.Encodings.Web;
using System.Text.Json;
using System.IO;
using WPF_UnityControl.Models;
using Microsoft.Win32;
using WPF_UnityControl.JsonPoco;
using System.Windows;
using WPF_UnityControl.Converter;

namespace WPF_UnityControl.Service
{
    /// <summary>
    /// ゲームオブジェクトデータのファイル操作クラス
    /// </summary>
    public class GameObjectFileService
    {
        /// <summary>
        /// Jsonファイルとして保存
        /// </summary>
        /// <param name="goData">ゲームオブジェクトでーた　</param>
        /// <param name="filePath">ファイルパス</param>
        public void SaveAsJson(GameObjectModel goData, string filePath)
        {
            if (!filePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                filePath += ".json";

            var json = JsonSerializer.Serialize(goData, new JsonSerializerOptions
            { // オプション指定
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Json作成時にキャメルケースに変換
            });

            //ファイル出力
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// ゲームオブジェクトファイルの読込
        /// </summary>
        /// <returns></returns>
        public GameObjectModel? LoadGameObjectJson()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "JSONファイルを選択"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                if (Path.GetExtension(filePath).Equals(".json", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        string jsonString = File.ReadAllText(filePath);

                        var goJson = JsonSerializer.Deserialize<JsonGameObject>(jsonString);
                        if (goJson != null)
                        {
                            return GameObjectConverter.ToModel(goJson);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"エラー : {ex.Message}", "読込失敗");
                    }
                }
                return null;
            }
            return null;
        }
    }
}
