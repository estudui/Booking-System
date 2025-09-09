namespace BookSystemApi.Dto.User
{
    public class ReqUser
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Full_Name { get; set; } = string.Empty;
        public int Position_id { get; set; }
        public int Division_id { get; set; }
    }
}