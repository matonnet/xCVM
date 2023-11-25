using System.Collections.Generic;
using UnityEngine;

namespace xCVM
{
    /// <summary>
    /// VRM0
    /// </summary>
    class xCVMMaterialValidator : UniGLTF.DefaultMaterialValidator
    {
        const string MTOON_SHADER_NAME = "xCVM/MToon10";

        public override string GetGltfMaterialTypeFromUnityShaderName(string shaderName)
        {
            switch (shaderName)
            {
                case MTOON_SHADER_NAME:
                    return "VRMC_materials_mtoon";
            }

            // TODO: VRM-0.X

            return base.GetGltfMaterialTypeFromUnityShaderName(shaderName);
        }

        public override IEnumerable<(string propertyName, Texture texture)> EnumerateTextureProperties(Material m)
        {
            if (m.shader.name == MTOON_SHADER_NAME)
            {
                // TODO
            }
            else
            {
                foreach (var x in base.EnumerateTextureProperties(m))
                {
                    yield return x;
                }
            }
        }
    }
}
