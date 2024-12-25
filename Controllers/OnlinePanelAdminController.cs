using System.Collections;
using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    public class OnlinePanelAdmin : ControllerBase
    
    {

        [HttpGet("/online_pannel/admin/requests")]
        public async Task<ActionResult<List<AdminDto.AdminRequestsDto>>>GetAllRequests()    // Получить все заявки
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/admin/requests/{Id}")]
        public async Task<ActionResult<AdminDto.AdminDetailRequestDto>>GetDetailsOfRequestsById()    // Получить детали заявки
        {
            
            return null;
            
        }
        
        [HttpPut("/online_pannel/admin/requests/{Id}")]
        public async Task<ActionResult<AdminDto.AdminNewResponsibleEmployeeRequestDto>> ChangeResponsibleEmployeeById()   // Поменять ответственного сотрудника
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/admin/employees")]
        public async Task<ActionResult<List<AdminDto.AdminGetAllEmployeesDto>>> GetAllEmployee()   // Получить всех сотрудников
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/admin/employees/{Id}")]
        public async Task<ActionResult<AdminDto.AdminDetailsEmployeeDTO>> GetEmployeeProfileDataById()   // Получить данные профиля сотрудника
        {
            
            return null;
            
        }

        [HttpPut("/online_pannel/admin/employees/{Id}")]
        public async Task<ActionResult<AdminDto.AdminUpdateEmployeeDto>> UpdateEmployeeProfile()   // Обновить профиль сотрудника
        {
            
            return null;
            
        }
        
        [HttpPost("/online_pannel/admin/employees/add")]
        public async Task<ActionResult<AdminDto.AdminAddEmployeeDto>> CreateEmployee()   // Добавить сотрудника
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/admin/adresses")]
        public async Task<ActionResult<List<AdminDto.AdminGetAllAdressesDTO>>> GetAllAdresses()   // Получить все адреса
        {
            
            return null;
            
        }
        
        [HttpPost("/online_pannel/admin/adress/add")]
        public async Task<ActionResult<AdminDto.AdminCreateAdressDto>> CreateAdress()   // Добавить адрес
        {
            
            return null;
            
        }
        
        [HttpPut("/online_pannel/admin/adresses/{Id}")]
        public async Task<ActionResult<AdminDto.AdminCreateAdressDto>> UpdateStatusAdress()   // Обновление статуса у адреса
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/admin_profile/{AdminId}")]
        public async Task<ActionResult<AdminDto.AdminProfileDto>> GetAdminDataById()   // Получить данные админа по ID
        {
            
            return null;
            
        }
        
        [HttpPut("/online_pannel/admin_profile/{AdminId}")]
        public async Task<ActionResult<AdminDto.AdminProfileDto>> UpdateAdminDataById ()   // Обновить данные админа по ID
        {
            
            return null;
            
        }
        
    }
    
