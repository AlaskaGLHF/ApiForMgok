using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("online_pannel/[action]")]
public class JointController : ControllerBase
{
    private readonly ErrorModelDto _errorModel = new ErrorModelDto(
        userResponse: "Произошла ошибка на сервере.",
        serverResponse: "Неизвестная ошибка."
    );
    
    [HttpPost]
    [ActionName("autharization")]
    [ProducesResponseType(typeof(ResponeLoginDto), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(423)]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    public async Task<ActionResult<ResponeLoginDto>> Auth([FromBody] LoginDto loginDto)
    {
        try
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Login) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                _errorModel.ServerResponse = "Переданы некорректные данные для авторизации.";
                return BadRequest(_errorModel); // 400: Некорректные данные
            }

            // Пример проверки данных
            if (loginDto.Login == "employee" && loginDto.Password == "securepassword")
            {
                var response = new ResponeLoginDto
                {
                    JwtToken = "example-jwt-token"
                };
                return Ok(response); // 200: Успешная авторизация
            }
            else if (loginDto.Login == "inactive_employee")
            {
                return StatusCode(423, "Пользователь не активен"); // 423: Пользователь не активен
            }
            else
            {
                return Unauthorized("Введено неправильное имя пользователя или пароль"); // 401: Неверные данные
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // 500: Ошибка сервера
        }
    }
}
