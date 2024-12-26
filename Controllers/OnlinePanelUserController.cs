using System.Collections;
using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnlinePanelUser : ControllerBase
    {
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
                if (1 > 0) // Проверка, что всегда возвращаем 200
                {
                    
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        [HttpGet("/online_pannel/user/requests/{Id}")]
        [ProducesResponseType(typeof(UserDto.RequestDetailsUserDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<UserDto.RequestDetailsUserDto>> GetRequestById(int id)   // Получить детали заявки
        {
            try
            {
                if (id > 0) // Проверка, что ID больше 0
                {
                    
                    return Ok();
                    
                }
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        [HttpPut("/online_pannel/user/requests/{Id}")]
        [ProducesResponseType(typeof(UserDto.UpdateDetailsUserDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<UserDto.UpdateDetailsUserDto>> AcceptRequestById(int id, UserDto.UpdateDetailsUserDto updateDetailsUserDto)     // Принять заявку и оставить комментарий
        {
            try
            {
                if (updateDetailsUserDto != null)  // Проверка, что данные для обновления не пустые
                {
                    // Пример успешного ответа
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
        public async Task<ActionResult<List<UserDto.MyRequestUserDto>>> GetAllEmployeesRequestsById(int UserId)    // Получить ЗАЯВКИ сотрудника по id
        {
            try
            {
                if (UserId > 0)  // Проверка, что ID больше 0
                {
                  
                    return Ok();
                    
                }
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        [HttpGet("/online_pannel/user_profile/{UserId}/")]
        [ProducesResponseType(typeof(AccountSettings.AccountSettingsDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<AccountSettings.AccountSettingsDto>> GetEmployeeDetailsById(int UserId)   // Получить ДАННЫЕ сотрудника по id
        {
            try
            {
                if (UserId > 0)  // Проверка, что ID больше 0
                {
                    
                    return Ok();
                    
                }
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        [HttpPut("/online_pannel/user_profile/{UserId}/")]
        [ProducesResponseType(typeof(AccountSettings.UpdateAccountSettingsDto), 200)] // Пример для успешного ответа (200)
        [ProducesResponseType(typeof(ErrorModelDto), 500)] // Пример для ошибки (500)
        public async Task<ActionResult<AccountSettings.UpdateAccountSettingsDto>> UpdateEmployeeDataById(int id, AccountSettings.UpdateAccountSettingsDto updateAccountSettingsDto)   // Обновить данные в профиле сотрудника
        {
            try
            {
                if (updateAccountSettingsDto != null)  // Проверка, что данные для обновления не пустые
                {
                    // Пример успешного ответа
                    return Ok();

                }
            }
            catch (Exception ex)
            {
                _errorModel.ServerResponse = ex.Message;
                return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
            }

            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }
    }
}
