using System.ComponentModel.DataAnnotations.Schema;

namespace BookSystemApi.Dto.User
{
    public class UserAuthDto
    {
        [Column("EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Column("PASSWORD_HASH")]
        public string Password_Hash { get; set; } = string.Empty;

        [Column("FULL_NAME")]
        public string Full_Name { get; set; } = string.Empty;
    }
}