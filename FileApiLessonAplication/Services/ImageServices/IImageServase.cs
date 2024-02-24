using FileApiLesson.Domen.Entitys.Models;

namespace FileApiLesson.Aplication.Services.ImageServices
{
    internal interface IImageServase
    {
        public Task<Image> CreateImage();
    }
}
