using System;
using UnityEngine;
using xCVM.FastSpringBones.Blittables;

namespace xCVM.FastSpringBones.System
{
    [Serializable]
    public struct FastSpringBoneJoint
    {
        public Transform Transform;
        public BlittableJoint Joint;
        public Quaternion DefaultLocalRotation;
    }
}