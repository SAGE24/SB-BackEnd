using System.Runtime.Serialization;
using static SB.COMMONS.Constants;

namespace SB.EXCEPTIONHANDLING.Dtos;
public class ErrorException : Exception, ISerializable
{
    public string TransactionId { get; set; }
    public int Status { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
    public ErrorException(int error, string message) : base(message) {
        Status = error;
        TransactionId = DateTime.Now.ToString(Formats.DD_MM_YYYY_HH_MM_SS_FFF);
    }
}
