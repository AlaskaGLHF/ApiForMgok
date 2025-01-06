using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;

namespace ApiForMgok.Repository
{
    public class TelegramBotRepos : ITelegramBotRepos
    {
        private readonly ApiForMgokContext _context;

        public TelegramBotRepos(ApiForMgokContext context)
        {
            _context = context;
        }

        public async Task<Request> Create(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Request> GetByChatId(int chatId)
        {
            return await _context.Requests.FindAsync(chatId);
        }
    }
}
