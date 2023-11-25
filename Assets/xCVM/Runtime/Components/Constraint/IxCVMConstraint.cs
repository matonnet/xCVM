using UnityEngine;

namespace xCVM
{
    public interface IxCVMConstraint
    {
        internal void Process();

        GameObject ConstraintTarget { get; }
    }
}
