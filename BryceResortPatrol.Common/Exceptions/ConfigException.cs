using System;
using System.Runtime.Serialization;

namespace BryceResortPatrol.Common.Exceptions
{
    public sealed class ConfigException : Exception
    {
        public ConfigException()
        {
        }

        public ConfigException(string message) : base(message)
        {
        }

        public ConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConfigException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
