using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl.Models
{
    public class TransformModel
    {
        public Vector3Model Position { get; set; } = new Vector3Model();
        public Vector3Model Rotation { get; set; } = new Vector3Model();
        public Vector3Model Scale { get; set; } = new Vector3Model();
    }
}
