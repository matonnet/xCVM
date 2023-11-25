using System;
using System.Collections.Generic;
using UnityEngine;

namespace xCVM
{
    public interface IxCVMAnimation : IDisposable
    {
        (INormalizedPoseProvider, ITPoseProvider) ControlRig { get; }
        IReadOnlyDictionary<ExpressionKey, Func<float>> ExpressionMap { get; }
        public void ShowBoxMan(bool enable);
        LookAtInput? LookAt { get; }
    }
}
