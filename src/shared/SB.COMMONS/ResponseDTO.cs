using static SB.COMMONS.Constants;

namespace SB.COMMONS;
public class ResponseDTO
{
    public ResponseDTO()
    {
        this.Status = StatusResponse.OK;
        this.Success = true;
        this.TransactionId = DateTime.Now.ToString(Formats.DD_MM_YYYY_HH_MM_SS_FFF);
    }

    public string TransactionId { get; set; }
    public int Status { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
}
