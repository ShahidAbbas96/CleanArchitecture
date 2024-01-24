using Clean.Application.Dtos.Users;
using Clean.Application.Dtos;

namespace Clean.Application.Services.Users
{
    public interface IUserService
    {
        public Task<ResponseDto> CreateUser(AddUserDto addUserDto);
        public Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted);
    }
}
