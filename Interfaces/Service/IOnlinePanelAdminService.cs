using ApiForMgok.Dtos;

namespace ApiForMgok.Interfaces.Service
{
    public interface IOnlinePanelAdminService
    {
        Task<List<AdminDto.AdminRequestsDto>> GetAllRequestAsync();
        Task<AdminDto.AdminDetailRequestDto> GetDetailsRequestByIdAsync(int id);
        Task<AdminDto.AdminNewResponsibleEmployeeRequestDto> ChangeResponsibleEmployeeAsync(AdminDto.AdminNewResponsibleEmployeeRequestDto responsibleEmployee, int id);
        Task<List<AdminDto.AdminGetAllEmployeesDto>> GetAllEmployeesAsync();
        Task<AdminDto.AdminDetailsEmployeeDto> GetDetailsEmployeeByIdAsync(int id);
        Task UpdateEmployeeByIdAsync(AdminDto.AdminUpdateEmployeeDto updateEmployeeDto, int id);
        Task CreateEmployeeAsync(AdminDto.AdminAddEmployeeDto addEmployeeDto);
        Task<List<AdminDto.AdminGetAllAdressesDto>> GetAllAdressesAsync();
        Task CreateAddressAsync(AdminDto.AdminCreateAdressDto createAdressDto);
        Task UpdateAddressAsync(AdminDto.AdminCreateAdressDto updateAdressDto, int id);

    }
}
