using System.IO;
using NUnit.Framework;
using UniGLTF;
using UniGLTF.Extensions.VRMC_vrm;
using UnityEngine;
using VRMShaders;

namespace xCVM.Test
{
    public class ApiSampleTests
    {
        VrmLib.Model ReadModel(string path)
        {
            var bytes = MigrationVrm.Migrate(File.ReadAllBytes(path));

            var data = new GlbLowLevelParser(path, bytes).Parse();

            var model = ModelReader.Read(data);
            return model;
        }

        GameObject BuildGameObject(xCVMData data, bool showMesh)
        {
            using (var loader = new xCVMImporter(data, null))
            {
                var loaded = loader.Load();
                if (showMesh)
                {
                    loaded.ShowMeshes();
                }
                loaded.EnableUpdateWhenOffscreen();
                return loaded.gameObject;
            }
        }

        [Test]
        public void Sample()
        {
            var path = "Tests/Models/Alicia_vrm-0.51/AliciaSolid_vrm-0.51.vrm";
            Debug.Log($"load: {path}");

            using (var data = new GlbFileParser(path).Parse())
            using (var migrated = xCVMData.Migrate(data, out xCVMData result, out MigrationData migration))
            {
                Assert.NotNull(result);

                var go = BuildGameObject(result, true);
                Debug.Log(go);

                // export
                var vrmBytes = xCVMExporter.Export(go, new EditorTextureSerializer());

                Debug.Log($"export {vrmBytes.Length} bytes");
            }
        }
    }
}
