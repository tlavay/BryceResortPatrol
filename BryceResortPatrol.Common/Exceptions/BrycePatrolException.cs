using System;
using System.Runtime.Serialization;

namespace BryceResortPatrol.Common.Exceptions;

[Serializable]
public class BrycePatrolException : Exception
{
    public BrycePatrolException()
    {
    }

    public BrycePatrolException(string message) : base(message)
    {
    }

    public BrycePatrolException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BrycePatrolException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}