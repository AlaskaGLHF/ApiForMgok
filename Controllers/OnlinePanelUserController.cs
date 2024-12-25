using System.Collections;
using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class OnlinePanelUser : ControllerBase
    {

        [HttpGet("/online_pannel/user/requests")]
        public async Task<ActionResult<List<UserDto.RequestUserDto>>>GetAllRequests()   //  Получить все заявки
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/user/requests/{Id}")]
        public async Task<ActionResult<UserDto.RequestDetailsUserDTO>> GetRequestById()   //  Получить детали заявки
        {
            
            return null;
            
        }
        
        [HttpPut("/online_pannel/user/requests/{Id}")]
        public async Task<ActionResult<UserDto.UpdateDetailsUserDTO>> AcceptRequestById()     //  Принять заявку и оставить комментарий
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/user/my_requests/{UserId}")]
        public async Task<ActionResult<UserDto.MyRequestUserDto>> GetAllEmployeesRequestsById()    // Получить ЗАЯВКИ сотрудника по id
        {
            
            return null;
            
        }
        
        [HttpGet("/online_pannel/user_profile/{UserId}/")]
        public async Task<ActionResult<AccountSettingsDTO>> GetEmployeeDetailsById()   // Получить ДАННЫЕ сотрудника по id
        {
            
            return null;
            
        }
        
        [HttpPut("/online_pannel/user_profile/{UserId}/")]
        public async Task<ActionResult<UpdateAccountSettingsDTO>> UpdateEmployeeDataById()   // Обновить данные в профиле сотрудника
        {
            
            return null;
            
        }
        
    }
    
