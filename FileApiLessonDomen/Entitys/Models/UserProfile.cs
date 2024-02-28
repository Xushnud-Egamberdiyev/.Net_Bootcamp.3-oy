using FileApiLesson.Domen.Entitys.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileApiLesson.Domen.Entitys.Models

{
    public class UserProfile
    {
        public int Id { get; set; }
        //Sardor
        [NotMapped]
        public IFormFile Picture { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }


        [MinLength(5), MaxLength(20)]
        public required string Login { get; set; }


        [MinLength(6)]
        public required string Password { get; set; }

        public string PicturePath { get; set; }
    }
}
