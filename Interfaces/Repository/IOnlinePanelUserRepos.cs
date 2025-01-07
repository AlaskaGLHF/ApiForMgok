using ApiForMgok.Models;

namespace ApiForMgok.Interfaces.Repository
{
    public interface IOnlinePanelUserRepos
    {
        Task<List<Request?>> GetAllRequestsAsync();
        Task<Request> GetRequestByIdAsync(int id);
        Task<Request?> UpdateRequestAsync(Request? request);
        Task<Request?> GetRequestByUserIdAsync (int userId);
        Task<Employee> GetProfileByUserIdAsync (int userId);
        Task<Employee> UpdateProfileAsync(Employee profile);
        public Task<List<Request>> GetRequestsByEmployeeIdAsync(int userId);


    }
}
