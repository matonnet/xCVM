using UniGLTF;
using UnityEngine;

namespace xCVM.Settings
{
    public abstract class MaterialDescriptorGeneratorFactory : ScriptableObject
    {
        public abstract IMaterialDescriptorGenerator Create();
    }
}