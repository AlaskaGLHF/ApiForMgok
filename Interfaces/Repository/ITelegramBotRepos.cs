using ApiForMgok.Models;

namespace ApiForMgok.Interfaces.Repository
{
    public interface ITelegramBotRepos
    {

        Task<Request> GetByChatId (int chatId);
        Task<Request> Create(Request request);

    }
}
