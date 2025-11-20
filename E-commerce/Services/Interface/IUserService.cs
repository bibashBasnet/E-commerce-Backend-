using E_commerce.Dtos.User;
using E_commerce.Models;

namespace E_commerce.Services.Interface
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAllUserAsync();
        public Task<UserDto?> GetUserByIdAsync(int id);
        public Task<UserDto> CreateUserAsync(RegisterUserDto userDto);
        public Task<UserDto?> DeleteUserAsync(int id);
        public Task<UpdatDto?> UpdateUserDetailAsync(int id, UpdatDto updateUserDetail);
    }
}
