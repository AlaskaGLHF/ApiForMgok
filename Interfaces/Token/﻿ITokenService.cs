using ApiForMgok.Models;

namespace ApiForMgok.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(Employee employee);
    }
}