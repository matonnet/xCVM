using System;
using System.Collections.Generic;
using UnityEngine;

namespace xCVM
{
    [Serializable]
    public class xCVMSpringBoneColliderGroup : MonoBehaviour
    {
        [SerializeField]
        public string Name;

        public string GUIName(int i) => $"{i:00}:{Name}";

        [SerializeField]
        public List<xCVMSpringBoneCollider> Colliders = new List<xCVMSpringBoneCollider>();
    }
}