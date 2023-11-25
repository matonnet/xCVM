using System;
using System.Collections.Generic;
using UnityEngine;

namespace xCVM
{
    internal readonly struct RuntimeMorphTargetBinding
    {
        public MorphTargetIdentifier TargetIdentifier { get; }
        public Action<float> WeightApplier { get; }

        public RuntimeMorphTargetBinding(MorphTargetIdentifier targetIdentifier, Action<float> weightApplier)
        {
            TargetIdentifier = targetIdentifier;
            WeightApplier = weightApplier;
        }
    }
}