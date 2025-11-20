using E_commerce.Models;

namespace E_commerce.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public DateOnly DOB { get;set;  }

        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
