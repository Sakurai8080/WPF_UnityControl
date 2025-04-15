using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl.JsonPoco
{
    public class HierarchyNode
    {
        public string Name { get; set; }
        public List<HierarchyNode> Children { get; set; } = new List<HierarchyNode>();

    }
}
