using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForMgok.Repository
{
    public class TelegramBotRepos : ITelegramBotRepos
    {
        private readonly ApiForMgokContext _context;

        public TelegramBotRepos(ApiForMgokContext context)
        {
            _context = context;
        }

        public async Task<Request?> CreateRequestAsync(Request? request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<List<Request?>> GetRequestByChatId(int chatId)
        {
            return await _context.Requests.Where(c => c.ChatId == chatId).ToListAsync();
        }
    }
}
