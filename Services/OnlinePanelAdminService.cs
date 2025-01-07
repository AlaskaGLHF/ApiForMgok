using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Interfaces.Service;
using ApiForMgok.Models;

namespace ApiForMgok.Services
{
    public class OnlinePanelAdminService : IOnlinePanelAdminService
    {
        private readonly IOnlinePanelAdminRepos _onlinePanelAdminRepos;

        public OnlinePanelAdminService(IOnlinePanelAdminRepos onlinePanelAdminRepos)
        {
            _onlinePanelAdminRepos = onlinePanelAdminRepos;
        }

        public async Task<AdminDto.AdminNewResponsibleEmployeeRequestDto> ChangeResponsibleEmployeeAsync(AdminDto.AdminNewResponsibleEmployeeRequestDto responsibleEmployee, int id)
        {
            var request = await _onlinePanelAdminRepos.GetRequestByIdAsync(id);

            if (request == null) return null;

            request.StatusId = responsibleEmployee.Status_Id;
            request.AddressId = responsibleEmployee.Address_Id;
            request.Cabinet = responsibleEmployee.Cabinet;
            request.CreatedDateTime = responsibleEmployee.Created_Date_Time;
            request.FullName = responsibleEmployee.Full_Name;
            request.EmployeeId = responsibleEmployee.Employee_Id;

            var updatedRequest = await _onlinePanelAdminRepos.UpdateRequestAsync(request);

            return new AdminDto.AdminNewResponsibleEmployeeRequestDto
            {
                Status_Id = updatedRequest.StatusId,
                Address_Id = updatedRequest.AddressId,
                Cabinet = updatedRequest.Cabinet,
                Created_Date_Time = updatedRequest.CreatedDateTime,
                Full_Name = updatedRequest.FullName,
                Employee_Id = updatedRequest.EmployeeId
            };
        }

        public async Task CreateAddressAsync(AdminDto.AdminCreateAdressDto createAdressDto)
        {
            var address = new Address
            {
                AddressName = createAdressDto.Address,
                Status = createAdressDto.Status
            };
            await _onlinePanelAdminRepos.CreateAddressAsync(address);
        }

        public async Task CreateEmployeeAsync(AdminDto.AdminAddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee
            {
                FullName = addEmployeeDto.FullName,
                PhoneNumber = addEmployeeDto.PhoneNumber,
                Email = addEmployeeDto.Email,
                Login = addEmployeeDto.Login,
                Password = addEmployeeDto.Password,
                Status = addEmployeeDto.Status,
                RoleId = addEmployeeDto.RoleId,
            };
            await _onlinePanelAdminRepos.CreateEmployeeAsync(employee);
        }

        public async Task<AdminDto.AdminProfileDto> GetAdminProfileByIdAsync(int id)
        {
            var admin = await _onlinePanelAdminRepos.GetEmployeeByIdAsync(id);
            if (admin == null) return null;
            return new AdminDto.AdminProfileDto
            {
                Id = admin.Id,
                FullName = admin.FullName,
                PhoneNumber = admin.PhoneNumber,
                Email = admin.Email,
                Comment = admin.Comment
            };
        }

        public async Task<List<AdminDto.AdminGetAllAdressesDto>> GetAllAdressesAsync()
        {
            var addresses = await _onlinePanelAdminRepos.GetAllAddressesAsync();

            return addresses.Select(addresses =>  new AdminDto.AdminGetAllAdressesDto
            {
                Id = addresses.Id,
                Address = addresses.AddressName,
                Status = addresses.Status
            }).ToList();
        }

        public async Task<List<AdminDto.AdminGetAllEmployeesDto>> GetAllEmployeesAsync()
        {
            var employees = await _onlinePanelAdminRepos.GetAllEmployeesAsync();

            return employees.Select(employees => new AdminDto.AdminGetAllEmployeesDto
            {
                Id = employees.Id,
                Full_Name = employees.FullName
            }).ToList();
        }

        public async Task<List<AdminDto.AdminRequestsDto>> GetAllRequestAsync()
        {
            var requests = await _onlinePanelAdminRepos.GetAllRequestsAsync();

            return requests.Select(requests => new AdminDto.AdminRequestsDto{
                Id = requests.Id,
                Full_Name = requests.FullName,
                Address_Id = requests.AddressId,
                Created_Date_Time = requests.CreatedDateTime,
                Cabinet = requests.Cabinet,
                Status_Id = requests.StatusId,
                Employee_Id = requests.EmployeeId,
            }).ToList();
        }

        public async Task<AdminDto.AdminDetailsEmployeeDto> GetDetailsEmployeeByIdAsync(int id)
        {
            var employee = await _onlinePanelAdminRepos.GetEmployeeByIdAsync(id);

            if (employee == null) return null;

            return new AdminDto.AdminDetailsEmployeeDto
            {
                Id = employee.Id,
                Full_Name = employee.FullName,
                Phone_Number = employee.PhoneNumber,
                Email = employee.Email,
                Login = employee.Login,
                Password = employee.Password,
                Comment = employee.Comment,
                Status = employee.Status
            };

        }
        public async Task<AdminDto.AdminDetailRequestDto> GetDetailsRequestByIdAsync(int id)
        {
            var request = await _onlinePanelAdminRepos.GetRequestByIdAsync(id);

            var employees = await _onlinePanelAdminRepos.GetAllEmployeesAsync();

            if (request == null) return null;

            return new AdminDto.AdminDetailRequestDto
            {
                Id = request.Id,
                Status_Id = request.StatusId,
                Address_Id = request.AddressId,
                Cabinet = request.Cabinet,
                Created_Date_Time = request.CreatedDateTime,
                Full_Name = request.FullName,
                Employee_Id = request.EmployeeId,
                Employee_List = employees,
            };

        }
        
        public async Task UpdateAddressAsync(AdminDto.AdminCreateAdressDto updateAdressDto, int id)
        {
            var address = await _onlinePanelAdminRepos.GetAddressByIdAsync(id);
            if(address == null) return;

            address.AddressName = updateAdressDto.Address;
            address.Status = updateAdressDto.Status;

            await _onlinePanelAdminRepos.UpdateAddressAsync(address);
        }

        public async Task UpdateAdminProfileAsync(AdminDto.AdminUpdateProfileDto adminUpdateProfileDto, int id)
        {
            var admin = await _onlinePanelAdminRepos.GetEmployeeByIdAsync(id);
            if(admin == null) return;

            admin.FullName = adminUpdateProfileDto.FullName;
            admin.PhoneNumber = adminUpdateProfileDto.PhoneNumber;
            admin.Email = adminUpdateProfileDto.Email;
            admin.Comment = adminUpdateProfileDto.Comment;

            await _onlinePanelAdminRepos.UpdateEmployeeAsync(admin);
        }

        public async Task UpdateEmployeeByIdAsync(AdminDto.AdminUpdateEmployeeDto updateEmployeeDto, int id)
        {
            var employee = await _onlinePanelAdminRepos.GetEmployeeByIdAsync(id);
            if (employee == null) return;

            employee.FullName = updateEmployeeDto.Full_Name;
            employee.PhoneNumber = updateEmployeeDto.Phone_Number;
            employee.Email = updateEmployeeDto.Email;
            employee.Login = updateEmployeeDto.Login;
            employee.Password = updateEmployeeDto.Password;
            employee.Comment = updateEmployeeDto.Comment;
            employee.Status = updateEmployeeDto.Status;

            await _onlinePanelAdminRepos.UpdateEmployeeAsync(employee);
        }

    }
}
