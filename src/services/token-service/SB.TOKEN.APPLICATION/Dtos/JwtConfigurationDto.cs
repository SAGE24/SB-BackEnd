namespace SB.TOKEN.APPLICATION.Dtos;
public class JwtConfigurationDto
{
    public static string KEY = "JwtConfiguration";
    public int Hours { get; set; }
    public string Secret { get; set; }
}
