using ApiForMgok.Dtos;

namespace ApiForMgok.Interfaces.Service
{
    public interface IOnlinePanelUserService
    {

        public Task<List<UserDto.RequestUserDto>> GetAllRequestsAsync();

        public Task<UserDto.RequestDetailsUserDto> GetRequestDetailsAsync(int requestId);

        public Task<UserDto.UpdateDetailsUserDto> GetRequestAndGiveComment(string userResponse, int requestId,
            int newStatusId);

        public Task<List<UserDto.MyRequestUserDto>> GetAllMyRequestsAsync(int userId);

        public Task<AccountSettings.AccountSettingsDto> GetEmployeeDataById(int userId);

        public Task<AccountSettings.UpdateAccountSettingsDto> UpdateEmployeeDataAsync(
            AccountSettings.AccountSettingsDto settings, int userId);
        
        

    }
}
