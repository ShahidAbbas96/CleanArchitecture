using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;
using Clean.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string? searchString, bool includeDeleted)
        {
            return await userService.GetAllUsers(pageNo, pageSize, searchString, includeDeleted);
        }
        [HttpPost]
        public async Task<ResponseDto> AddUser(AddUserDto userDto)
        {
            return await userService.CreateUser(userDto);
        }
    }
}
