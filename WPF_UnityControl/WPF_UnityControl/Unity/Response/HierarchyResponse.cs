using Newtonsoft.Json;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_UnityControl.Interface;
using WPF_UnityControl.JsonPoco;

namespace WPF_UnityControl.Response
{
    public class HierarchyResponse : IResponseData
    {

        public ReactivePropertySlim<List<HierarchyNode>> HierarchyList { get; } = new ReactivePropertySlim<List<HierarchyNode>>();


        public void Execute(string json)
        {
            var hierarchyJson = JsonConvert.DeserializeObject<string[]>(json);

            if (hierarchyJson?.Length >= 1)
            {
                var nodes = JsonConvert.DeserializeObject<List<HierarchyNode>>(hierarchyJson[0]);
                HierarchyList.Value = nodes;
            }
        }

    }
}
