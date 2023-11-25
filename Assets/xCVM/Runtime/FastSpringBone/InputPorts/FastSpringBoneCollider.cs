using System;
using UnityEngine;
using xCVM.FastSpringBones.Blittables;

namespace xCVM.FastSpringBones.System
{
    [Serializable]
    public struct FastSpringBoneCollider
    {
        public Transform Transform;
        public BlittableCollider Collider;
    }
}