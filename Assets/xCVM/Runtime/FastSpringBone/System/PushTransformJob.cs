using Unity.Collections;
using UnityEngine.Jobs;
using xCVM.FastSpringBones.Blittables;
#if ENABLE_SPRINGBONE_BURST
using Unity.Burst;
#endif

namespace xCVM.FastSpringBones.System
{
#if ENABLE_SPRINGBONE_BURST
    [BurstCompile]
#endif
    public struct PushTransformJob : IJobParallelForTransform
    {
        [ReadOnly]
        public NativeArray<BlittableTransform> Transforms;

        public void Execute(int index, TransformAccess transform)
        {
            transform.rotation = Transforms[index].rotation;
        }
    }
}