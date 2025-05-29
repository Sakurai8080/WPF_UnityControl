using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl.Models
{
    public class GameObjectModel
    {
        public string Name { get; set; }

        public string Tag { get; set; }

        public string Layer { get; set; }

        public bool IsActive { get; set; }

        public TransformModel Transform { get; }
    }
}
