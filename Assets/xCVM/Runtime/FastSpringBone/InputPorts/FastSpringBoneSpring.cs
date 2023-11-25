using System;
using UnityEngine;

namespace xCVM.FastSpringBones.System
{
    [Serializable]
    public struct FastSpringBoneSpring
    {
        public Transform center;
        public FastSpringBoneJoint[] joints;
        public FastSpringBoneCollider[] colliders;
    }
}