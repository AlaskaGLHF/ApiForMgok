using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using ApiForMgok.Services; // Путь к вашему S3-сервису, если он в отдельном namespace

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
    private readonly IS3Service _s3Service; // Добавляем поле для S3-сервиса

    
    public TelegramBotController(ITelegramBotService telegramBotService, IS3Service s3Service)
    {
        _telegramBotService = telegramBotService;
        _s3Service = s3Service; // Инициализация S3-сервиса
    }

    [HttpPost]
    [ActionName("create_request")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult<string>> Create(
        [FromBody] TelegramBotDto.TelegramBotRequestDto telegramBotDto)
    {
        try
        {
            // Загружаем фото с URL
            var photoStream = await _telegramBotService.DownloadPhotoAsync(telegramBotDto.Photo);
            var fileName = $"{Guid.NewGuid()}.jpg";  // Генерация уникального имени для файла
            var photoPath = $"{telegramBotDto.ChatId}/{fileName}";  // Формируем путь для фото

            // Загружаем фото в Yandex Object Storage и получаем правильный URL
            var uploadedPhotoUrl = await _s3Service.UploadFileAsync(photoStream, photoPath);

            // Передаем корректный URL фото в DTO
            telegramBotDto.Photo = uploadedPhotoUrl;

            // Создаем запрос в базе данных
            await _telegramBotService.CreateRequestAsync(telegramBotDto);

            return Ok("Запрос успешно создан");
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // Возврат ошибки сервера
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
