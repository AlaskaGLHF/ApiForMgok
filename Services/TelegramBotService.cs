using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Interfaces.Service;
using ApiForMgok.Models;

namespace ApiForMgok.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ITelegramBotRepos _telegramBotRepos;

        public TelegramBotService(ITelegramBotRepos telegramBotRepos)
        {
            _telegramBotRepos = telegramBotRepos;
        }

        public async Task<TelegramBotDto.TelegramBotRequestDto> CreateRequestAsync(TelegramBotDto.TelegramBotRequestDto telegramBotDto)
        {
            var request = new Request
            {
                ChatId = telegramBotDto.ChatId,
                AddressId = telegramBotDto.AddressId,
                Cabinet = telegramBotDto.Cabinet,
                FullName = telegramBotDto.FullName,
                PhoneNumber = telegramBotDto.PhoneNumber,
                Description = telegramBotDto.Description,
                Photo = telegramBotDto.Photo

            };
            
            var createdRequest = await _telegramBotRepos.CreateRequestAsync(request);
            return new TelegramBotDto.TelegramBotRequestDto
            {
                ChatId = createdRequest.ChatId,
                AddressId = createdRequest.AddressId,
                Cabinet = createdRequest.Cabinet,
                FullName = createdRequest.FullName,
                PhoneNumber = createdRequest.PhoneNumber,
                Description = createdRequest.Description,
                Photo = createdRequest.Photo

            };
        }

        public async Task<List<TelegramBotDto.TelegramBotResponseDto>> GetRequestAsync(int chatId)
        {
            
            var request = await _telegramBotRepos.GetRequestByChatId(chatId);

            if (request == null) return null;

            return request.Select(request => new TelegramBotDto.TelegramBotResponseDto
            {
                Id = request.Id,
                ChatId = request.ChatId,
                AddressId = request.AddressId,
                Cabinet = request.Cabinet,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Description = request.Description,
                CreatedDateTime = request.CreatedDateTime,
                StatusId = request.StatusId,
            }).ToList();
        }
        
        public async Task<Stream> DownloadPhotoAsync(string photoUrl)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(photoUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }

        
    }
}
