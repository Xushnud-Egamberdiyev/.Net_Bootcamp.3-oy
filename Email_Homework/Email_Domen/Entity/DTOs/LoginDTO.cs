using System.ComponentModel.DataAnnotations;

namespace Email_Domen.Entity.DTOs
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
