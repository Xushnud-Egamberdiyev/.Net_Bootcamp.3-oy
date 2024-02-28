using System.ComponentModel.DataAnnotations;

namespace Email_Domen.Entity.DTOs
{
    public class SingUpDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmationcode { get; set; }
    }
}
