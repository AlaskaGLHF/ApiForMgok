using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForMgok.Repository
{
    public class OnlinePanelAdminRepos : IOnlinePanelAdminRepos
    {

        private readonly ApiForMgokContext _context;

        public OnlinePanelAdminRepos(ApiForMgokContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAddressAsync(Address newaddress)
        {
            _context.Addresses.Add(newaddress);
            await _context.SaveChangesAsync();
            return newaddress;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Request> UpdateRequestAsync(Request request)
        {
            _context.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
