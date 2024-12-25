using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("telegram_bot/[action]")]
public class TelegramBotController
{
    [HttpPost]
    [ActionName("create_request")]
    public async Task<ActionResult<TelegramBotDto.TelegrammBotRequestDTO>> Create(
        TelegramBotDto.TelegrammBotResponseDTO createDto)
    {
        throw new Exception();
    }
    
    [HttpGet("{ChatId}")]
    public async Task<ActionResult<TelegramBotDto.TelegrammBotResponseDTO>> GetById (int ChatId)
    {
        throw new Exception();
    } 
}

