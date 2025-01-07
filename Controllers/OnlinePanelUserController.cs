using System.Collections;
using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnlinePanelUser : ControllerBase
    {
        
        private readonly IOnlinePanelUserService _onlinePanelUserService;

        public OnlinePanelUser(IOnlinePanelUserService onlinePanelUserService)
        {
            
            _onlinePanelUserService = onlinePanelUserService;
            
        }
        
        private readonly ErrorModelDto _errorModel = new ErrorModelDto(
            userResponse: "Произошла ошибка на сервере.",
            serverResponse: "Неизвестная ошибка."
        );

        
        
        [HttpGet("/online_pannel/user/requests")]
        [ProducesResponseType(typeof(List<UserDto.RequestUserDto>), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<List<UserDto.RequestUserDto>>> GetAllRequests()   // Получить все заявки
        {
            try
            {
                
                var requests = await _onlinePanelUserService.GetAllRequestsAsync();
                return Ok(requests);
                
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  
            }
        }

        
        
        [HttpGet("/online_pannel/user/requests/{id}")]
        [ProducesResponseType(typeof(UserDto.RequestDetailsUserDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<UserDto.RequestDetailsUserDto>> GetRequestDetailsById(int id)   // Получить детали заявки NOT
        {
            try
            {

                var request = await _onlinePanelUserService.GetRequestDetailsAsync(id);
                if (request == null) return StatusCode(404, _errorModel);
                return Ok(request);

            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }
            
        }

        
        
        [HttpPut("/online_pannel/user/requests/{id}")]
        [ProducesResponseType(typeof(UserDto.UpdateDetailsUserDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<UserDto.UpdateDetailsUserDto>> AcceptRequestById(int id, UserDto.UpdateDetailsUserDto updateDetailsUserDto)     // Принять заявку и оставить комментарий
        {
            try
            {

                if (await _onlinePanelUserService.GetAllMyRequestsAsync(id) == null)
                {
                    return StatusCode(400, _errorModel);
                }
                else
                {
                    return Ok("Заявка успешно поменяла статус или добавлен комментарий");
                }
                    
                
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        
        
        [HttpGet("/online_pannel/user/my_requests/{UserId}")]
        [ProducesResponseType(typeof(List<UserDto.MyRequestUserDto>), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        [ProducesResponseType(typeof(ErrorModelDto), 404)] // Пример для случая отсутствия данных (404)
        public async Task<ActionResult<List<UserDto.MyRequestUserDto>>> GetAllEmployeesRequestsById(int UserId) // Получить ЗАЯВКИ сотрудника по id
        {
            try
            {
                // Получаем все заявки сотрудника с фильтрацией по EmployeeId
                var requests = await _onlinePanelUserService.GetAllMyRequestsAsync(UserId);

                // Если заявок нет после выполнения метода, вернем ошибку 404
                if (requests == null || !requests.Any())
                {
                    _errorModel.ServerResponse = "Заявки для данного сотрудника не найдены.";
                    return StatusCode(404, _errorModel);
                }

                // Возвращаем список заявок с успешным кодом 200
                return Ok(requests);
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);
            }
        }

        
        
        [HttpGet("/online_pannel/user_profile/{UserId}/")]
        [ProducesResponseType(typeof(AccountSettings.AccountSettingsDto), 200)]
        [ProducesResponseType(typeof(ErrorModelDto), 500)]
        public async Task<ActionResult<AccountSettings.AccountSettingsDto>> GetEmployeeDetailsById(int UserId)   // Получить ДАННЫЕ сотрудника по id
        {
            try
            {

                var employee = await _onlinePanelUserService.GetEmployeeDataById(UserId);
                
                if (employee == null) return StatusCode(404, _errorModel);
                
                return Ok(employee);

            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }
        }

        
        
        [HttpPut("/online_pannel/user_profile/{userId}/")]
        [ProducesResponseType(typeof(AccountSettings.UpdateAccountSettingsDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<AccountSettings.UpdateAccountSettingsDto>> UpdateEmployeeDataById(
            int userId, 
            AccountSettings.AccountSettingsDto updateAccountSettingsDto) // Обновить данные в профиле сотрудника
        {
            try
            {
                // Обновляем данные сотрудника через сервис
                var updatedProfile = await _onlinePanelUserService.UpdateEmployeeDataAsync(updateAccountSettingsDto, userId);
        
                // Возвращаем обновленные данные с успешным кодом
                return Ok(updatedProfile);
            }
            catch (NullReferenceException)
            {
                _errorModel.ServerResponse = "Сотрудник не найден.";
                return StatusCode(404, _errorModel); // Если сотрудник не найден, возвращаем ошибку 404
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }
        }

    }
}
