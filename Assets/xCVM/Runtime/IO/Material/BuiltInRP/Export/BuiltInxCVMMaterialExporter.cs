using UniGLTF;
using UnityEngine;
using VRMShaders;

namespace xCVM
{
    public class BuiltInxCVMMaterialExporter : IMaterialExporter
    {
        private readonly BuiltInGltfMaterialExporter _gltfExporter = new BuiltInGltfMaterialExporter();

        public glTFMaterial ExportMaterial(Material m, ITextureExporter textureExporter, GltfExportSettings settings)
        {
            if (BuiltInxCVMMToonMaterialExporter.TryExportMaterialAsMToon(m, textureExporter, out var dst))
            {
                return dst;
            }
            else
            {
                return _gltfExporter.ExportMaterial(m, textureExporter, settings);
            }
        }
    }
}
