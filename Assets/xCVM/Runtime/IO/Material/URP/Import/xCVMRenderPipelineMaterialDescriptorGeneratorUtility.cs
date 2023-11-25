using UniGLTF;

namespace xCVM
{
    public class xCVMRenderPipelineMaterialDescriptorGeneratorDescriptorUtility : RenderPipelineMaterialDescriptorGeneratorUtility
    {
        public static IMaterialDescriptorGenerator GetValidxCVMMaterialDescriptorGenerator()
        {
            switch (GetRenderPipelineType())
            {
                case RenderPipelineTypes.UniversalRenderPipeline:
                    return new UrpxCVMMaterialDescriptorGenerator();
                case RenderPipelineTypes.BuiltinRenderPipeline:
                    return new BuiltInxCVMMaterialDescriptorGenerator();
            }

            return null;
        }
    }
}