using ApiForMgok.Models;
using System.Runtime.CompilerServices;

namespace ApiForMgok.Interfaces.Repository
{
    public interface IOnlinePanelAdminRepos
    {

        Task<List<Request>> GetAllRequestsAsync();
        Task<Request> GetRequestByIdAsync(int id);
        Task<Request> UpdateRequestAsync(Request request);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task CreateAddressAsync(Address newaddress);
        Task<Address> UpdateAddressAsync(Address address);

    }
}
