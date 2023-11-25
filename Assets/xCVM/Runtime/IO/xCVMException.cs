using System;

namespace xCVM
{
    public class xCVMException : Exception
    {
        public xCVMException(string msg) : base(msg)
        { }
    }

    public class xCVMNoExtensionException : xCVMException
    {
        public xCVMNoExtensionException(string msg) : base(msg)
        { }
    }
}
