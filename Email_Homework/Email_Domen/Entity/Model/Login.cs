using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Email_Domen.Entity.Model
{
    public class Login
    {
        public int ID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        [JsonIgnore]
        public string SendCode { get; set; } = string.Empty;
    }
}
