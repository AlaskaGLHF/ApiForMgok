using ApiForMgok.Dtos;
using ApiForMgok.Interfaces;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Models;
using ApiForMgok.Repository;

namespace ApiForMgok.Services
{
    public class JointService
    {
        private readonly IJointRepos _jointRepos;
        private readonly ITokenService _tokenService;

        // Конструктор для внедрения зависимостей
        public JointService(IJointRepos jointRepos, ITokenService tokenService)
        {
            _jointRepos = jointRepos ?? throw new ArgumentNullException(nameof(jointRepos));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<ResponeLoginDto?> AuthenticateAsync(LoginDto loginDto)
        {
            // Получаем сотрудника по логину
            var employee = await _jointRepos.GetByLoginAsync(loginDto.Login.ToLower());

            if (employee == null)
            {
                return null;
            }

            // Проверяем пароль
            if (loginDto.Password != employee.Password)
            {
                return null;
            }

            // Создаём JWT токен
            var jwtToken = _tokenService.CreateToken(employee);

            return new ResponeLoginDto
            {
                JwtToken = jwtToken
            };
        }
    }
}
