using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace xCVM
{
    public sealed class xCVMHumanoidBoneSpecification
    {
        /// <summary>
        /// https://github.com/vrm-c/vrm-specification/blob/master/specification/VRMC_vrm-1.0/humanoid.md
        /// </summary>
        private readonly List<xCVMHumanoidBoneAttribute> _specification = new List<xCVMHumanoidBoneAttribute>
        {
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Hips, true, null, null, HumanBodyBones.Hips),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Spine, true, xCVMHumanoidBones.Hips, null, HumanBodyBones.Spine),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Chest, false, xCVMHumanoidBones.Spine, null, HumanBodyBones.Chest),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.UpperChest, false, xCVMHumanoidBones.Chest, true, HumanBodyBones.UpperChest),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Neck, false, xCVMHumanoidBones.UpperChest, false, HumanBodyBones.Neck),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Head, true, xCVMHumanoidBones.Neck, false, HumanBodyBones.Head),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftEye, false, xCVMHumanoidBones.Head, null, HumanBodyBones.LeftEye),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightEye, false, xCVMHumanoidBones.Head, null, HumanBodyBones.RightEye),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.Jaw, false, xCVMHumanoidBones.Head, null, HumanBodyBones.Jaw),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftUpperLeg, true, xCVMHumanoidBones.Hips, null, HumanBodyBones.LeftUpperLeg),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftLowerLeg, true, xCVMHumanoidBones.LeftUpperLeg, null, HumanBodyBones.LeftLowerLeg),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftFoot, true, xCVMHumanoidBones.LeftLowerLeg, null, HumanBodyBones.LeftFoot),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftToes, false, xCVMHumanoidBones.LeftFoot, null, HumanBodyBones.LeftToes),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightUpperLeg, true, xCVMHumanoidBones.Hips, null, HumanBodyBones.RightUpperLeg),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightLowerLeg, true, xCVMHumanoidBones.RightUpperLeg, null, HumanBodyBones.RightLowerLeg),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightFoot, true, xCVMHumanoidBones.RightLowerLeg, null, HumanBodyBones.RightFoot),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightToes, false, xCVMHumanoidBones.RightFoot, null, HumanBodyBones.RightToes),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftShoulder, false, xCVMHumanoidBones.UpperChest, false, HumanBodyBones.LeftShoulder),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftUpperArm, true, xCVMHumanoidBones.LeftShoulder, false, HumanBodyBones.LeftUpperArm),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftLowerArm, true, xCVMHumanoidBones.LeftUpperArm, null, HumanBodyBones.LeftLowerArm),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftHand, true, xCVMHumanoidBones.LeftLowerArm, null, HumanBodyBones.LeftHand),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightShoulder, false, xCVMHumanoidBones.UpperChest, false, HumanBodyBones.RightShoulder),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightUpperArm, true, xCVMHumanoidBones.RightShoulder, false, HumanBodyBones.RightUpperArm),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightLowerArm, true, xCVMHumanoidBones.RightUpperArm, null, HumanBodyBones.RightLowerArm),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightHand, true, xCVMHumanoidBones.RightLowerArm, null, HumanBodyBones.RightHand),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftThumbMetacarpal, false, xCVMHumanoidBones.LeftHand, null, HumanBodyBones.LeftThumbProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftThumbProximal, false, xCVMHumanoidBones.LeftThumbMetacarpal, true, HumanBodyBones.LeftThumbIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftThumbDistal, false, xCVMHumanoidBones.LeftThumbProximal, true, HumanBodyBones.LeftThumbDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftIndexProximal, false, xCVMHumanoidBones.LeftHand, null, HumanBodyBones.LeftIndexProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftIndexIntermediate, false, xCVMHumanoidBones.LeftIndexProximal, true, HumanBodyBones.LeftIndexIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftIndexDistal, false, xCVMHumanoidBones.LeftIndexIntermediate, true, HumanBodyBones.LeftIndexDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftMiddleProximal, false, xCVMHumanoidBones.LeftHand, null, HumanBodyBones.LeftMiddleProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftMiddleIntermediate, false, xCVMHumanoidBones.LeftMiddleProximal, true, HumanBodyBones.LeftMiddleIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftMiddleDistal, false, xCVMHumanoidBones.LeftMiddleIntermediate, true, HumanBodyBones.LeftMiddleDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftRingProximal, false, xCVMHumanoidBones.LeftHand, null, HumanBodyBones.LeftRingProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftRingIntermediate, false, xCVMHumanoidBones.LeftRingProximal, true, HumanBodyBones.LeftRingIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftRingDistal, false, xCVMHumanoidBones.LeftRingIntermediate, true, HumanBodyBones.LeftRingDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftLittleProximal, false, xCVMHumanoidBones.LeftHand, null, HumanBodyBones.LeftLittleProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftLittleIntermediate, false, xCVMHumanoidBones.LeftLittleProximal, true, HumanBodyBones.LeftLittleIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.LeftLittleDistal, false, xCVMHumanoidBones.LeftLittleIntermediate, true, HumanBodyBones.LeftLittleDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightThumbMetacarpal, false, xCVMHumanoidBones.RightHand, null, HumanBodyBones.RightThumbProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightThumbProximal, false, xCVMHumanoidBones.RightThumbMetacarpal, true, HumanBodyBones.RightThumbIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightThumbDistal, false, xCVMHumanoidBones.RightThumbProximal, true, HumanBodyBones.RightThumbDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightIndexProximal, false, xCVMHumanoidBones.RightHand, null, HumanBodyBones.RightIndexProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightIndexIntermediate, false, xCVMHumanoidBones.RightIndexProximal, true, HumanBodyBones.RightIndexIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightIndexDistal, false, xCVMHumanoidBones.RightIndexIntermediate, true, HumanBodyBones.RightIndexDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightMiddleProximal, false, xCVMHumanoidBones.RightHand, null, HumanBodyBones.RightMiddleProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightMiddleIntermediate, false, xCVMHumanoidBones.RightMiddleProximal, true, HumanBodyBones.RightMiddleIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightMiddleDistal, false, xCVMHumanoidBones.RightMiddleIntermediate, true, HumanBodyBones.RightMiddleDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightRingProximal, false, xCVMHumanoidBones.RightHand, null, HumanBodyBones.RightRingProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightRingIntermediate, false, xCVMHumanoidBones.RightRingProximal, true, HumanBodyBones.RightRingIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightRingDistal, false, xCVMHumanoidBones.RightRingIntermediate, true, HumanBodyBones.RightRingDistal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightLittleProximal, false, xCVMHumanoidBones.RightHand, null, HumanBodyBones.RightLittleProximal),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightLittleIntermediate, false, xCVMHumanoidBones.RightLittleProximal, true, HumanBodyBones.RightLittleIntermediate),
            new xCVMHumanoidBoneAttribute(xCVMHumanoidBones.RightLittleDistal, false, xCVMHumanoidBones.RightLittleIntermediate, true, HumanBodyBones.RightLittleDistal),
        };

        private readonly Dictionary<xCVMHumanoidBones, xCVMHumanoidBoneAttribute> _specDictionary;
        private readonly Dictionary<xCVMHumanoidBones, HumanBodyBones> _toUnity;
        private readonly Dictionary<HumanBodyBones, xCVMHumanoidBones> _fromUnity;

        private xCVMHumanoidBoneSpecification()
        {
            _specDictionary = _specification.ToDictionary(x => x.Bone, x => x);
            _toUnity = _specification.ToDictionary(x => x.Bone, x => x.UnityBone);
            _fromUnity = _specification.ToDictionary(x => x.UnityBone, x => x.Bone);
        }

        private static xCVMHumanoidBoneSpecification _instance;

        private static xCVMHumanoidBoneSpecification Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new xCVMHumanoidBoneSpecification();
                }
                return _instance;
            }
        }

        public static xCVMHumanoidBoneAttribute GetDefine(xCVMHumanoidBones bone)
        {
            return Instance._specDictionary[bone];
        }

        public static HumanBodyBones ConvertToUnityBone(xCVMHumanoidBones bone)
        {
            return Instance._toUnity[bone];
        }

        public static xCVMHumanoidBones ConvertFromUnityBone(HumanBodyBones bone)
        {
            return Instance._fromUnity[bone];
        }
    }
}