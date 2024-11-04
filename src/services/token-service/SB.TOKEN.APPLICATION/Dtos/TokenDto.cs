namespace SB.TOKEN.APPLICATION.Dtos;
public class TokenDto
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpireOn { get; set; }
}
