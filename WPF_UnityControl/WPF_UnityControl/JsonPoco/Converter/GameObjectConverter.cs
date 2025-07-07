using WPF_UnityControl.Models;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.Converter
{
    /// <summary>
    /// ゲームオブジェクトデータを変換するコンバータークラス
    /// </summary>
    public static class GameObjectConverter
    {
        /// <summary>
        /// モデルクラスへの変換
        /// </summary>
        /// <param name="goJson"></param>
        /// <returns>ゲームオブジェクトモデルクラス</returns>
        public static GameObjectModel ToModel(JsonGameObject goJson)
        {
            var transform = goJson.Transform;

            return new GameObjectModel
            {
                Name = goJson.Name,
                Tag = goJson.Tag,
                Layer = goJson.Layer,
                IsActive = goJson.IsActive,
                Transform = transform == null ? null : new TransformModel
                {
                    Position = transform.Position == null ? null : new Vector3Model
                    {
                        X = transform.Position.X,
                        Y = transform.Position.Y,
                        Z = transform.Position.Z
                    },
                    Rotation = transform.Rotation == null ? null : new Vector3Model
                    {
                        X = transform.Rotation.X,
                        Y = transform.Rotation.Y,
                        Z = transform.Rotation.Z
                    },
                    Scale = transform.Scale == null ? null : new Vector3Model
                    {
                        X = transform.Scale.X,
                        Y = transform.Scale.Y,
                        Z = transform.Scale.Z
                    }
                }
            };
        }

        /// <summary>
        /// モデルクラスからJsonに変換
        /// </summary>
        /// <param name="goModel">ゲームオブジェクトモデル</param>
        /// <returns>ゲームオブジェクトJson</returns>
        public static JsonGameObject ToJson(GameObjectModel goModel)
        {

            var transform = goModel.Transform;

            return new JsonGameObject
            {
                Name = goModel.Name,
                Tag = goModel.Tag,
                Layer = goModel.Layer,
                IsActive = goModel.IsActive,
                Transform = transform == null ? null : new JsonTransform
                {
                    Position = transform.Position == null ? null : new JsonVector3
                    {
                        X = transform.Position.X,
                        Y = transform.Position.Y,
                        Z = transform.Position.Z
                    },
                    Rotation = transform.Rotation == null ? null : new JsonVector3
                    {
                        X = transform.Rotation.X,
                        Y = transform.Rotation.Y,
                        Z = transform.Rotation.Z
                    },
                    Scale = transform.Scale == null ? null : new JsonVector3
                    {
                        X = transform.Scale.X,
                        Y = transform.Scale.Y,
                        Z = transform.Scale.Z
                    }
                }
            };
        }
    }
}
