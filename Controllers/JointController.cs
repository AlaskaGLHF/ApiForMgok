using ApiForMgok.Dtos;
using ApiForMgok.Interfaces;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("online_panel/[action]")]
public class JointController : ControllerBase
{
    private readonly IJointRepos _jointRepos;
    private readonly ITokenService _tokenService;
    private readonly ErrorModelDto _errorModel;

    public JointController(IJointRepos jointRepos, ITokenService tokenService)
    {
        _jointRepos = jointRepos;
        _tokenService = tokenService;
        _errorModel = new ErrorModelDto(
            userResponse: "Произошла ошибка на сервере.",
            serverResponse: "Неизвестная ошибка."
        );
    }

    [HttpPost]
    [ActionName("authorization")]
    [ProducesResponseType(typeof(ResponeLoginDto), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(423)]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    public async Task<ActionResult<ResponeLoginDto>> Authorization([FromBody] LoginDto loginDto)
    {
        try
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Login) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                _errorModel.ServerResponse = "Переданы некорректные данные для авторизации.";
                return BadRequest(_errorModel); // 400: Некорректные данные
            }

            // Получение пользователя из базы
            var employee = await _jointRepos.GetByLoginAsync(loginDto.Login.ToLower());

            if (employee == null)
            {
                return Unauthorized("Введено неправильное имя пользователя или пароль"); // 401: Неверные данные
            }

            if (loginDto.Password != employee.Password)
            {
                return Unauthorized("Введено неправильное имя пользователя или пароль"); // 401: Неверные данные
            }

            if (!employee.Status)
            {
                return StatusCode(423, "Пользователь не активен"); // 423: Пользователь не активен
            }

            var token = _tokenService.CreateToken(employee);

            var response = new ResponeLoginDto
            {
                JwtToken = token
            };

            return Ok(response); // 200: Успешная авторизация
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // 500: Ошибка сервера
        }
    }
}
