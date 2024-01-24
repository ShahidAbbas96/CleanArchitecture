using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;
using Clean.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ResponseDto> CreateUser(AddUserDto addUserDto)
        {
          return  await this.userRepository.CreateUser(addUserDto);
        }

        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
           return await userRepository.GetAllUsers(pageNo, pageSize, searchString, includeDeleted);
        }
    }
}
