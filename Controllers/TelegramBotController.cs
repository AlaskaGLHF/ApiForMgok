using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("telegram_bot/[action]")]
public class TelegramBotController : ControllerBase
{
    private readonly ErrorModelDto _errorModel = new ErrorModelDto(
        userResponse: "Произошла ошибка на сервере.",
        serverResponse: "Неизвестная ошибка."
    );

    [HttpPost]
    [ActionName("create_request")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(TelegramBotDto.TelegrammBotRequestDto), 200)]
    public async Task<ActionResult<TelegramBotDto.TelegrammBotRequestDto>> Create(
        [FromBody] TelegramBotDto.TelegrammBotResponseDto createDto)
    {
        try
        {
            if (createDto == null)
            {
                _errorModel.ServerResponse = "Переданы некорректные данные для создания запроса.";
                return BadRequest(_errorModel); // Возврат 400 для некорректных данных
            }

            var createdRequest = new TelegramBotDto.TelegrammBotRequestDto
            {
                // Заполните пример данных запроса здесь
                ChatId = createDto.ChatId,
                
            };

            return Ok("Заявка успешно созданна"); // Успешный ответ
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // Возврат ошибки сервера
        }
    }

    [HttpGet("{ChatId}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(TelegramBotDto.TelegrammBotResponseDto), 200)]
    public async Task<ActionResult<TelegramBotDto.TelegrammBotResponseDto>> GetById(int ChatId)
    {
        try
        {
            if (ChatId <= 0)
            {
                _errorModel.ServerResponse = "Передан некорректный идентификатор чата.";
                return BadRequest(_errorModel); // Возврат 400 для некорректного ID
            }

            var response = new TelegramBotDto.TelegrammBotResponseDto
            {
                // Заполните пример данных ответа здесь
                ChatId = ChatId,
                
            };

            return Ok("Заявки пользователя успешно найдены"); // Успешный ответ
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // Возврат ошибки сервера
        }
    }
}
