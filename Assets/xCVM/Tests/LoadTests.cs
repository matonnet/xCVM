using NUnit.Framework;
using UniGLTF;

namespace xCVM.Test
{
    public class LoadTests
    {
        [Test]
        public void EmptyThumbnailName()
        {
            using (var data = new GlbFileParser(TestAsset.AliciaPath).Parse())
            using (var migrated = xCVMData.Migrate(data, out var vrm1Data, out var migration))
            {
                // xCVMData.ParseOrMigrate(TestAsset.AliciaPath, true, out xCVMData vrm, out MigrationData migration))
                Assert.NotNull(vrm1Data);

                var index = vrm1Data.VrmExtension.Meta.ThumbnailImage.Value;

                // empty thumbnail name
                vrm1Data.Data.GLTF.images[index].name = null;

                using (var loader = new xCVMImporter(vrm1Data))
                {
                    loader.LoadAsync(new VRMShaders.ImmediateCaller()).Wait();
                }
            }
        }
    }
}
