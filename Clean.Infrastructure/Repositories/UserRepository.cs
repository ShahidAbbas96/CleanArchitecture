using AutoMapper;
using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;
using Clean.Application.Interface;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public UserRepository(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ResponseDto> CreateUser(AddUserDto addUserDto)
        {
            var Response = new ResponseDto();
            try
            {
                var user = this.mapper.Map<User>(addUserDto);
                await this.db.Users.AddAsync(user);
                await this.db.SaveChangesAsync();
                Response.Status = true;
                Response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {

                Response.Status = false;
                Response.Message = ex.Message;
            }
            return Response;

        }

        public Task<ResponseDto> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
            var Response = new ResponseDto();
            try
            {
                //CreateProjectUsingCmd crud = new CreateProjectUsingCmd();
                //crud.CreateProjectCmd();
                var query = this.db.Users.Where(u => u.IsDeleted == includeDeleted)
                       .Select(u => new
                       {
                           u.ID,
                           u.Surname,
                           u.Email,
                           u.Password,
                           u.FirstName,
                           u.IsDeleted
                       });
                int totalCount = query.Count();
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(u => u.FirstName.Contains(searchString));
                }
                var user = await query
                    .OrderBy(u => u.ID)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                var response = new
                {
                    TotalCounts = totalCount,
                    Users = user
                };
                Response.Status = true;
                Response.Message = "Success";
                Response.Data = response;

            }
            catch (Exception ex)
            {
                Response.Status = false;
                Response.Message = ex.Message;

            }
            return Response;
        }

        public Task<ResponseDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> RestoreUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateUser(EditUserDto editUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
