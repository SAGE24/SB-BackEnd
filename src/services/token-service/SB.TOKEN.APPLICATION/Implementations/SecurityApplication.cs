using Microsoft.Extensions.Options;

namespace SB.TOKEN.APPLICATION.Implementations;
public class SecurityApplication : ISecurityApplication
{
    private readonly JwtConfigurationDto _jwtConfigurationDto;

    public SecurityApplication(IOptions<JwtConfigurationDto> jwtConfigurationDto)
    {
        _jwtConfigurationDto = jwtConfigurationDto.Value;
    }

    public TokenDto JwtSecurity()
    {
        string jwtSecrectKey = _jwtConfigurationDto.Secret;
        int hours = _jwtConfigurationDto.Hours;
        DateTime now = DateTime.Now;

        List<Claim> claims = new() {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        DateTime expireDateTime = now.AddHours(hours);

        JwtSecurityTokenHandler handler = new();

        byte[] key = Encoding.UTF8.GetBytes(jwtSecrectKey);
        SymmetricSecurityKey symmetricSecurityKey = new(key);
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new(
            claims: claims,
            expires: expireDateTime,
            notBefore: now,
            signingCredentials: signingCredentials
            );

        return new()
        {
            AccessToken = handler.WriteToken(jwtSecurityToken),
            ExpireOn = expireDateTime
        };
    }
}
