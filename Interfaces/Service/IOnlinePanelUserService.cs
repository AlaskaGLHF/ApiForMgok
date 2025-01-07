using ApiForMgok.Dtos;

namespace ApiForMgok.Interfaces.Service
{
    public interface IOnlinePanelUserService
    {

        public Task<List<TelegramBotDto.TelegramBotResponseDto>> GetAllRequestsAsync();

        
        
    }
}
