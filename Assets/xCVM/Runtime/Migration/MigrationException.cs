using System;

namespace xCVM
{
    internal class MigrationException : Exception
    {
        public MigrationException(string key, string value) : base($"{key}: {value}")
        {
        }
    }
}
