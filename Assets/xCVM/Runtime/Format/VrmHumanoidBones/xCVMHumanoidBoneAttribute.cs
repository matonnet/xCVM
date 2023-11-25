using UnityEngine;

namespace xCVM
{
    public readonly struct xCVMHumanoidBoneAttribute
    {
        public xCVMHumanoidBones Bone { get; }
        public bool IsRequired { get; }
        public xCVMHumanoidBones? ParentBone { get; }
        public bool? NeedsParentBone { get; }
        public HumanBodyBones UnityBone { get; }

        public xCVMHumanoidBoneAttribute(xCVMHumanoidBones bone, bool isRequired, xCVMHumanoidBones? parentBone, bool? needsParentBone, HumanBodyBones unityBone)
        {
            Bone = bone;
            IsRequired = isRequired;
            ParentBone = parentBone;
            NeedsParentBone = needsParentBone;
            UnityBone = unityBone;
        }
    }
}