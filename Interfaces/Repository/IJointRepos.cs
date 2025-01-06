using ApiForMgok.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForMgok.Interfaces.Repository
{
    public interface IJointRepos
    {

        public Task<Employee> GetByLoginAsync(string login);

    }
}
