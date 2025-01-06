using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ApiForMgok.Repository
{
    public class JointRepos : IJointRepos
    {

        private readonly ApiForMgokContext _context;

        // Конструктор для внедрения контекста
        public JointRepos(ApiForMgokContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Employee> GetByLoginAsync(string login)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(u => u.Login.ToLower() == login.ToLower());
        }

    }
}
