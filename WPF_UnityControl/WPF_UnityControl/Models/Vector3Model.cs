using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UnityControl.Models
{
    public class Vector3Model
    {
        public ReactivePropertySlim<float> X { get; set; } = new ReactivePropertySlim<float>();
        public ReactivePropertySlim<float> Y { get; set; } = new ReactivePropertySlim<float>();
        public ReactivePropertySlim<float> Z { get; set; } = new ReactivePropertySlim<float>();
    }
}
