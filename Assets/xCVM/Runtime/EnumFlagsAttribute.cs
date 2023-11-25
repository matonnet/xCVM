using System;
using UnityEngine;

namespace xCVM
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public sealed class EnumFlagsAttribute : PropertyAttribute { }
}
