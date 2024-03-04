using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Email_Domen.Entity.Model
{
    public class Login
    {
        public int Id { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? SendCode { get; set; }
    }
}
