using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForMgok.Repository
{
    public class OnlinePanelUserRepos : IOnlinePanelUserRepos
    {
        private readonly ApiForMgokContext _context;

        public OnlinePanelUserRepos(ApiForMgokContext context)
        {
            _context = context;
        }

        public async Task<List<Request?>> GetAllRequestsAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request?> GetRequestByUserIdAsync(int userId)
        {
            return await _context.Requests.
                FirstOrDefaultAsync(c => c.EmployeeId == userId);
        }

        public async Task<Employee> GetProfileByUserIdAsync(int userId)
        {
            return await _context.Employees.FindAsync(userId);
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
            
        }

        public async Task<Employee> UpdateProfileAsync(Employee profile)
        {
            _context.Employees.Update(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task<Request?> UpdateRequestAsync(Request? request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        
        public async Task<List<Request?>> GetAllRequestsByEmployeeId(int userId)
        {
            return await _context.Requests
                .Where(c => c.EmployeeId == userId)
                .ToListAsync();
        }
        
        public async Task<List<Request>> GetRequestsByEmployeeIdAsync(int userId)
        {
            return await _context.Requests.Where(r => r.EmployeeId == userId).ToListAsync();
        }

    }
}
