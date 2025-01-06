using ApiForMgok.Dtos;

namespace ApiForMgok.Interfaces.Service
{
    public interface IJointService
    {

        public Task<ResponeLoginDto?> AuthenticateAsync(LoginDto loginDto);

    }
}
