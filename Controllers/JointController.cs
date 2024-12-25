using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("online_pannel/[action]")]
public class JointController : ControllerBase
{
    [HttpPost]
    [ActionName("autharization")]
    public async Task<ActionResult<ResponeLoginDto>> auth(LoginDto loginDto)
    {
        throw new Exception();
    }
}