using System;

namespace xCVM
{
    public class ConstraintException : Exception
    {
        public enum ExceptionTypes
        {
            NoSource,
            NoModelWithModelSpace
        }

        public readonly ExceptionTypes Type;

        public ConstraintException(ExceptionTypes type)
        {
            Type = type;
        }
    }
}
