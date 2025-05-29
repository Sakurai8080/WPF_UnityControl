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
        public ReactivePropertySlim<float> X { get; } = new ReactivePropertySlim<float>();
        public ReactivePropertySlim<float> Y { get; } = new ReactivePropertySlim<float>();
        public ReactivePropertySlim<float> Z { get; } = new ReactivePropertySlim<float>();
    }
}
