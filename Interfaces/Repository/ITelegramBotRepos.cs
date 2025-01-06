using ApiForMgok.Models;

namespace ApiForMgok.Interfaces.Repository
{
    public interface ITelegramBotRepos
    {

        Task<List<Request>> GetRequestByChatId (int chatId);
        Task<Request> CreateRequestAsync(Request request);

    }
}
