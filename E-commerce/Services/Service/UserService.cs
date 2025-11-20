using E_commerce.Context;
using E_commerce.Dtos.User;
using E_commerce.Migrations;
using E_commerce.Models;
using E_commerce.Services.Interface;
using E_commerce.Utiltiy;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Services.Service
{
    public class UserService(ECommerceContext _context): IUserService
    {
        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var userList = await _context.users.Include(u => u.Credential).ToListAsync();
            return userList.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                DOB = u.DOB,
                Phone = u.Phone,  
                UserName = u.Credential!.UserName
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.users
                .Include(u => u.Credential)
                .FirstOrDefaultAsync(u => u.UserId == id);
            if (user is null)
                return null;
            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Phone = user.Phone,
                DOB = user.DOB,
                UserName = user.Credential!.UserName
            };
        }

        public async Task<UserDto> CreateUserAsync(RegisterUserDto user)
        {

            UserDetail newUser = new UserDetail {
                Name = user.Name,
                DOB = user.DOB,
                Phone = user.Phone,
                Credential = new UserCredential
                {
                    UserName = user.UserName,
                    Password = PasswordUtility.HashPassword(user.Password)
                }
            };
            await _context.users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                DOB = newUser.DOB,
                Phone = newUser.Phone,
                UserName = newUser.Credential.UserName
            };
        }

        public async Task<UserDto?> DeleteUserAsync(int id)
        {
            var user = await _context.users.Include(u => u.Credential)
                .FirstOrDefaultAsync(u => u.UserId == id);  
            if(user is null) 
                return null;
            UserDto deletedUser = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                DOB = user.DOB,
                Phone = user.Phone,
                UserName = user.Credential!.UserName
            };
            if (user.Credential is not null)
                _context.credentials.Remove(user.Credential);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            
            return deletedUser;
        }

        public async Task<UpdatDto?> UpdateUserDetailAsync(int id, UpdatDto updatedUserDetail)
        {
            var user = await _context.users
                .Include(u => u.Credential)
                .FirstOrDefaultAsync(u => u.UserId == id);
            if (user is null)
                return null;
            user.Name = updatedUserDetail.Name;
            user.DOB = updatedUserDetail.DOB;
            user.Phone = updatedUserDetail.Phone;
            await _context.SaveChangesAsync();
            var updatedUser = new UpdatDto
            {
                UserId = user.UserId,
                Name = user.Name,
                DOB = user.DOB,
                Phone = user.Phone
            };
            return updatedUser;

        }
    }
}
