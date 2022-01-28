using System.Runtime.Serialization;

namespace TripServiceKata.Exceptions;

[Serializable]
public class DependendClassCallDuringUnitTestException : Exception
{
    public DependendClassCallDuringUnitTestException()
        : base()
    {
    }

    public DependendClassCallDuringUnitTestException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    public DependendClassCallDuringUnitTestException(string message)
        : base(message)
    {
    }

    private DependendClassCallDuringUnitTestException(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
    {
    }
}
