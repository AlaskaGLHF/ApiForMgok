using ApiForMgok.Dtos;
using ApiForMgok.Interfaces.Repository;
using System.Linq;
using ApiForMgok.Interfaces.Service;
using ApiForMgok.Models;

namespace ApiForMgok.Services
{
    public class OnlinePanelUserService : IOnlinePanelUserService
    {
        
        private readonly IOnlinePanelUserRepos _onlinePanelUserRepos;

        public OnlinePanelUserService(IOnlinePanelUserRepos onlinePanelUserRepos)
        {
            _onlinePanelUserRepos = onlinePanelUserRepos;
        }

        // Получение всех запросов
        public async Task<List<UserDto.RequestUserDto>> GetAllRequestsAsync()
        {
            var requests = await _onlinePanelUserRepos.GetAllRequestsAsync();
            
            return requests.Select(request => new UserDto.RequestUserDto()
            {
                Id = request.Id,
                FullName = request.FullName,
                AddressId = request.AddressId,
                CreatedDateTime = request.CreatedDateTime,
                Cabinet = request.Cabinet
            }).ToList();
        }

        // Получение деталей запроса по ID
        public async Task<UserDto.RequestDetailsUserDto> GetRequestDetailsAsync(int requestId)
        {
            var request = await _onlinePanelUserRepos.GetRequestByIdAsync(requestId);
            
            if (request == null) return null;

            return new UserDto.RequestDetailsUserDto()
            {
                Id = request.Id,
                StatusId = request.StatusId,
                AddressId = request.AddressId,
                Cabinet = request.Cabinet,
                CreatedDateTime = request.CreatedDateTime,
                FullName = request.FullName,
                Description = request.Description,
                Photo = request.Photo,
                CommentEmployee = request.EmployeeComment
            };
        }

        // Метод для получения запроса и добавления комментария
        public async Task<UserDto.UpdateDetailsUserDto> GetRequestAndGiveComment(string userResponse, int requestId, int newStatusId)
        {
            // Получаем заявку по её ID
            var request = await _onlinePanelUserRepos.GetRequestByIdAsync(requestId);

            if (request == null) return null;

            // Обновляем комментарий сотрудника и статус заявки
            request.EmployeeComment = userResponse;
            request.StatusId = 2; // Обновляем статус заявки

            // Сохраняем изменения
            await _onlinePanelUserRepos.UpdateRequestAsync(request);

            // Возвращаем DTO с обновленными данными
            return new UserDto.UpdateDetailsUserDto()
            {
                StatusId = request.StatusId,
                AddressId = request.AddressId,
                Cabinet = request.Cabinet,
                CreatedDateTime = request.CreatedDateTime,
                FullName = request.FullName,
                Description = request.Description,
                Photo = request.Photo,
                CommentEmployee = request.EmployeeComment // Обновленное поле комментария сотрудника
            };
        }


        // Получение всех запросов для конкретного пользователя
        public async Task<List<UserDto.MyRequestUserDto>> GetAllMyRequestsAsync(int userId)
        {
            // Получаем заявки для сотрудника с указанным userId, используя метод репозитория
            var requests = await _onlinePanelUserRepos.GetRequestsByEmployeeIdAsync(userId);

            // Если заявок нет, выбрасываем исключение
            if (requests == null || !requests.Any())
            {
                throw new NullReferenceException("Заявки для данного сотрудника не найдены");
            }

            // Преобразуем список заявок в список DTO и возвращаем
            return requests.Select(request => new UserDto.MyRequestUserDto
            {
                Id = request.Id,
                FullName = request.FullName,
                AddressId = request.AddressId,
                CreatedDateTime = request.CreatedDateTime,
                Cabinet = request.Cabinet,
                StatusId = request.StatusId,
                EmployeeId = request.EmployeeId
            }).ToList();
        }


        
        // Получение данных сотрудника по ID
        public async Task<AccountSettings.AccountSettingsDto> GetEmployeeDataById(int userId)
        {
            var employee = await _onlinePanelUserRepos.GetProfileByUserIdAsync(userId);

            if (employee == null) throw new NullReferenceException();

            return new AccountSettings.AccountSettingsDto
            {
                FullName = employee.FullName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Login = employee.Login,
                Password = employee.Password,
                Comment = employee.Comment,
            };
        }

        // Обновление данных сотрудника
        public async Task<AccountSettings.UpdateAccountSettingsDto> UpdateEmployeeDataAsync(
            AccountSettings.AccountSettingsDto settings, int userId)
        {
            var employee = await _onlinePanelUserRepos.GetProfileByUserIdAsync(userId);

            if (employee == null) throw new NullReferenceException();

            // Обновление данных сотрудника
            employee.FullName = settings.FullName;
            employee.PhoneNumber = settings.PhoneNumber;
            employee.Email = settings.Email;
            employee.Login = settings.Login;
            employee.Password = settings.Password;
            employee.Comment = settings.Comment;

            // Сохранение обновленных данных
            await _onlinePanelUserRepos.UpdateProfileAsync(employee);

            // Возвращаем обновленные данные
            return new AccountSettings.UpdateAccountSettingsDto
            {
                FullName = employee.FullName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Login = employee.Login,
                Password = employee.Password,
                Comment = employee.Comment
            };
        }
    }
}
