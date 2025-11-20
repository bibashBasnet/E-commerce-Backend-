using E_commerce.Dtos.User;
using E_commerce.Services.Interface;
using E_commerce.Utiltiy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Collections.Generic;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await userService.GetAllUserAsync();
                if (users is null)
                {
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                }
                return Ok(new SuccessResponse<IEnumerable<UserDto>>(users, "User list retrieved successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await userService.GetUserByIdAsync(id);
                if (user is null)
                {
                    return NotFound(new ErrorResponse<string>("User not found."));
                }
                return Ok(new SuccessResponse<UserDto>(user, "User retrieved successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await userService.GetUserByIdAsync(id);
                if (user is null)
                    return NotFound(new ErrorResponse<string>("User not found."));
                var deletedUser = await userService.DeleteUserAsync(id);
                return Ok(new SuccessResponse<UserDto>(deletedUser, "User deleted successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(RegisterUserDto user)
        {
            try
            {
                var newUser = await userService.CreateUserAsync(user);
                if (newUser is null)
                    return BadRequest(new ErrorResponse<string> ("Something went wrong."));
                return Ok(new SuccessResponse<UserDto>(newUser, "User created successfully."));
            }
            catch (Exception) { 
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserDetail(int id, UpdatDto updatedUserDetail) {
            try
            {
                var user = await userService.UpdateUserDetailAsync(id, updatedUserDetail);
                if (user is null)
                    return BadRequest(new ErrorResponse<string>("User not found"));
                return Ok(new SuccessResponse<UpdatDto>(user, "User updated successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
            

        }
    }
}
