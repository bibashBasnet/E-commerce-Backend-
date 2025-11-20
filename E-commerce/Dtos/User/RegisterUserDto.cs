namespace E_commerce.Dtos.User
{
    public class RegisterUserDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }

        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
