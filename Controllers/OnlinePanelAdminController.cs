using System.Collections;
using ApiForMgok.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OnlinePanelAdmin : ControllerBase
{
    private readonly ErrorModelDto _errorModel = new ErrorModelDto(
        userResponse: "Произошла ошибка на сервере.",
        serverResponse: "Неизвестная ошибка."
    );

    [HttpGet("/online_pannel/admin/requests")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(List<AdminDto.AdminRequestsDto>), 200)]
    public async Task<ActionResult<List<AdminDto.AdminRequestsDto>>> GetAllRequests()    // Получить все заявки
    {
        try
        {
            // Пример успешного ответа с кодом 200
            var requests = new List<AdminDto.AdminRequestsDto>(); // Здесь должен быть список заявок
            return Ok(requests); // Возврат успешного ответа
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }
    }

    [HttpGet("/online_pannel/admin/requests/{Id}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminDetailRequestDto), 200)]
    public async Task<ActionResult<AdminDto.AdminDetailRequestDto>> GetDetailsOfRequestsById(int id)    // Получить детали заявки
    {
        try
        {
            if (id > 0) // Проверка, что ID больше 0
            {
                var requestDetails = new AdminDto.AdminDetailRequestDto(); // Здесь должны быть детали заявки
                return Ok(requestDetails); // Возврат успешного ответа с кодом 200
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось найти заявку.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpPut("/online_pannel/admin/requests/{Id}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminNewResponsibleEmployeeRequestDto), 200)]
    public async Task<ActionResult<AdminDto.AdminNewResponsibleEmployeeRequestDto>> ChangeResponsibleEmployeeById(
        int id, 
        [FromBody] AdminDto.AdminNewResponsibleEmployeeRequestDto adminNewResponsibleEmployeeRequestDto)   // Поменять ответственного сотрудника
    {
        try
        {
            if (adminNewResponsibleEmployeeRequestDto == null)
            {
                return BadRequest(_errorModel); // Возврат 400 для некорректных данных
            }
            // Пример успешного обновления
            return Ok("Ответственный за заявку успешно изменён");
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }
    }

    [HttpGet("/online_pannel/admin/employees")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(List<AdminDto.AdminGetAllEmployeesDto>), 200)]
    public async Task<ActionResult<List<AdminDto.AdminGetAllEmployeesDto>>> GetAllEmployee()   // Получить всех сотрудников
    {
        try
        {
            var employees = new List<AdminDto.AdminGetAllEmployeesDto>(); // Список сотрудников
            return Ok(employees); // Возврат успешного ответа
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }
    }

    [HttpGet("/online_pannel/admin/employees/{Id}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminDetailsEmployeeDto), 200)]
    public async Task<ActionResult<AdminDto.AdminDetailsEmployeeDto>> GetEmployeeProfileDataById(int id)   // Получить данные профиля сотрудника
    {
        try
        {
            if (id > 0)  // Проверка, что ID больше 0
            {
                var employeeData = new AdminDto.AdminDetailsEmployeeDto(); // Данные сотрудника
                return Ok(employeeData); // Возврат успешного ответа
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось найти данные сотрудника.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpPut("/online_pannel/admin/employees/{Id}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminUpdateEmployeeDto), 200)]
    public async Task<ActionResult<AdminDto.AdminUpdateEmployeeDto>> UpdateEmployeeProfile(int id, AdminDto.AdminUpdateEmployeeDto adminUpdateEmployeeDto)   // Обновить профиль сотрудника
    {
        try
        {
            if (adminUpdateEmployeeDto != null)  // Проверка, что данные для обновления не пустые
            {
                return Ok("Профиль сотрудника успешно обновлён");
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось обновить профиль сотрудника.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpPost("/online_pannel/admin/employees/add")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminAddEmployeeDto), 200)]
    public async Task<ActionResult<AdminDto.AdminAddEmployeeDto>> CreateEmployee(AdminDto.AdminAddEmployeeDto adminAddEmployeeDto)   // Добавить сотрудника
    {
        try
        {
            if (adminAddEmployeeDto != null)  // Проверка, что данные для создания сотрудника не пустые
            {
                return Ok("Сотрудник успешно добавлен");
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось добавить сотрудника.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpGet("/online_pannel/admin/adresses")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(List<AdminDto.AdminGetAllAdressesDto>), 200)]
    public async Task<ActionResult<List<AdminDto.AdminGetAllAdressesDto>>> GetAllAdresses()   // Получить все адреса
    {
        try
        {
            var addresses = new List<AdminDto.AdminGetAllAdressesDto>(); // Список адресов
            return Ok(addresses); // Возврат успешного ответа
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }
    }

    [HttpPost("/online_pannel/admin/adress/add")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminCreateAdressDto), 200)]
    public async Task<ActionResult<AdminDto.AdminCreateAdressDto>> CreateAdress(AdminDto.AdminCreateAdressDto adminCreateAdressDto)   // Добавить адрес
    {
        try
        {
            if (adminCreateAdressDto != null)  // Проверка, что данные для добавления адреса не пустые
            {
                return Ok("Адрес успешно добавлен");
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось добавить адрес.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpPut("/online_pannel/admin/adresses/{Id}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminCreateAdressDto), 200)]
    public async Task<ActionResult<AdminDto.AdminCreateAdressDto>> UpdateStatusAdress(int id, AdminDto.AdminCreateAdressDto adminCreateAdressDto)   // Обновление статуса у адреса
    {
        try
        {
            if (adminCreateAdressDto != null)  // Проверка, что данные для обновления статуса не пустые
            {
                return Ok("Статус адреса успешно обновлён");
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось обновить статус адреса.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpGet("/online_pannel/admin_profile/{AdminId}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminProfileDto), 200)]
    public async Task<ActionResult<AdminDto.AdminProfileDto>> GetAdminDataById(int id)  // Получить данные админа по ID
    {
        try
        {
            if (id > 0)  // Проверка, что ID больше 0
            {
                var adminData = new AdminDto.AdminProfileDto(); // Данные администратора
                return Ok(adminData); // Возврат успешного ответа
            }
        }
        catch (Exception ex)
        {
            _errorModel.ServerResponse = ex.Message;
            return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
        }

        _errorModel.ServerResponse = "Не удалось найти данные администратора.";
        return StatusCode(500, _errorModel);  // В случае ошибки сервер возвращает 500
    }

    [HttpPut("/online_pannel/admin_profile/{AdminId}")]
    [ProducesResponseType(typeof(ErrorModelDto), 500)]
    [ProducesResponseType(typeof(AdminDto.AdminUpdateProfileDto), 200)]
    public async Task<ActionResult<AdminDto.AdminUpdateProfileDto>> UpdateAdminDataById(int id, AdminDto.AdminUpdateProfileDto adminUpdateProfileDto)   // Обновить данные админа по ID
    {
        try
        {
            if (adminUpdateProfileDto != null)  // Проверка, что данные для обновления не пустые
            {
                return Ok("Данные администратора успешно обновлены");
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
