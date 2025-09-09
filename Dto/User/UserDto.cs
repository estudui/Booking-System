namespace BookSystemApi.Dto.User
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password_Hash { get; set; } = string.Empty;
        public string Full_Name { get; set; } = string.Empty;
        public int Position_id { get; set; }
        public int Division_id { get; set; }
    }
}