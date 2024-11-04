
namespace SB.TOKEN.SERVICE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ISecurityApplication _securityApplication;
    private readonly ILogger<TokenController> _logger;

    public TokenController(ISecurityApplication securityApplication, ILogger<TokenController> logger)
    {
        _securityApplication = securityApplication;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult GenerateToken() {
        TokenDto token = _securityApplication.JwtSecurity();

        ResponseDTO response = new() { 
            Data = token
        };

        return new JsonResult(response);
    }
}
