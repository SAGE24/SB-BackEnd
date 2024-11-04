using SB.Entity.Application.Dtos;
using SB.EXCEPTIONHANDLING.Dtos;

namespace SB.Entity.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntityController : ControllerBase
{
    private readonly IEntityApplication _entityApplication;

    public EntityController(IEntityApplication entityApplication)
    {
        _entityApplication = entityApplication;
    }

    [HttpGet("all/{fact?}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO))]
    public async Task<IActionResult> GetAll(string? fact) {
        ResponseDTO response = new()
        {
            Data = await _entityApplication.GetAll(fact)
        };

        return new JsonResult(response);
    }

    [HttpGet("record/{code}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO))]
    public async Task<IActionResult> Get(int code)
    {
        ResponseDTO response = new()
        {
            Data = await _entityApplication.Get(code)
        };

        return new JsonResult(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO))]
    public async Task<IActionResult> Post(EntitySaveDto record) {
        ResponseDTO response = new()
        {
            Data = await _entityApplication.Post(record)
        };

        return new JsonResult(response);
    }

    [HttpPut("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO))]
    public async Task<IActionResult> Put(int code, EntityUpdateDto record)
    {
        ResponseDTO response = new()
        {
            Data = await _entityApplication.Put(code, record)
        };

        return new JsonResult(response);
    }

    [HttpDelete("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO))]
    public async Task<IActionResult> Delete(int code) {
        ResponseDTO response = new()
        {
            Data = await _entityApplication.Delete(code)
        };

        return new JsonResult(response);
    }
}
