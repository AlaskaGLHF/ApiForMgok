using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Service;
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

    private readonly ITelegramBotService _telegramBotService;

    public TelegramBotController(ITelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    [HttpPost]
    [ActionName("create_request")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(TelegramBotDto.TelegramBotRequestDto), 200)]
    public async Task<ActionResult<TelegramBotDto.TelegramBotRequestDto>> Create(
        [FromBody] TelegramBotDto.TelegramBotRequestDto telegramBotDto)
    {
        try
        {
            var createRequest = await _telegramBotService.CreateRequestAsync(telegramBotDto);
            return Ok(createRequest); // Успешный возврат данных
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // Возврат ошибки сервера
        }
    }

    [HttpGet("{chatId}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(TelegramBotDto.TelegramBotResponseDto), 200)]
    public async Task<ActionResult<TelegramBotDto.TelegramBotResponseDto>> GetById(int chatId)
    {
        try
        {

            var requests = await _telegramBotService.GetRequestAsync(chatId);
            
            if (requests == null) return NotFound(_errorModel);
            
            return Ok(requests);

        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel); // Возврат ошибки сервера
        }
    
    }
    }

