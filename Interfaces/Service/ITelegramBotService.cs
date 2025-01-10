using ApiForMgok.Dtos;

namespace ApiForMgok.Interfaces.Service
{
    public interface ITelegramBotService
    {

        public  Task<TelegramBotDto.TelegramBotRequestDto> CreateRequestAsync(
            TelegramBotDto.TelegramBotRequestDto telegramBotDto);

        public Task<List<TelegramBotDto.TelegramBotResponseDto>> GetRequestAsync(int chatId);

        public Task<Stream> DownloadPhotoAsync(string photoUrl);

    }
}
