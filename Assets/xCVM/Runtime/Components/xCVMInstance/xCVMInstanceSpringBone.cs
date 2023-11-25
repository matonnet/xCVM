using System;
using System.Collections.Generic;
using UnityEngine;

namespace xCVM
{
    /// <summary>
    /// SpringBone の情報をすべて保持する
    /// 
    /// * SpringBoneCollider
    /// * SpringBoneJoint
    /// 
    /// は、個別の MonoBehaviour として設定する
    /// 
    /// </summary>
    [Serializable]
    public sealed class xCVMInstanceSpringBone
    {
        [SerializeField]
        public List<xCVMSpringBoneColliderGroup> ColliderGroups = new List<xCVMSpringBoneColliderGroup>();

        [Serializable]
        public class Spring
        {
            [SerializeField]
            public string Name;

            public string GUIName(int i) => $"{i:00}:{Name}";

            [SerializeField]
            public List<xCVMSpringBoneColliderGroup> ColliderGroups = new List<xCVMSpringBoneColliderGroup>();

            [SerializeField]
            public List<xCVMSpringBoneJoint> Joints = new List<xCVMSpringBoneJoint>();

            [SerializeField]
            public Transform Center;

            public Spring(string name)
            {
                Name = name;
            }

            public IEnumerable<(xCVMSpringBoneJoint, Transform)> EnumHeadTail()
            {
                for (int i = 0; i < Joints.Count; ++i)
                {
                    var head = Joints[i];
                    if (head == null)
                    {
                        continue;
                    }
                    for (int j = i + 1; j < Joints.Count; ++j)
                    {
                        var tail = Joints[j];
                        if (tail != null)
                        {
                            yield return (head, tail.transform);
                            break;
                        }
                    }
                }
            }
        }

        [SerializeField]
        public List<Spring> Springs = new List<Spring>();
    }
}
