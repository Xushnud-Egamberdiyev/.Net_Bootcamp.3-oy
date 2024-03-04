using Email_Homework.Controllers.AuthCantrollers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.ExternalServices
{
    public class UserProfileExternalService
    {
        private readonly IWebHostEnvironment _env;
        public UserProfileExternalService(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }   


        public async Task<string> AddPictureAndGetPath(FileModel file)
        {
            var wwwpath = _env.WebRootPath;
            var filePath = Guid.NewGuid() + "-" + file.Photo.FileName;
            var fullFilePath = Path.Combine(wwwpath, "images", filePath);

            using (var stream = System.IO.File.Create(fullFilePath))
            {
                await file.Photo.CopyToAsync(stream);


            }

            return fullFilePath;

            //string path = Path.Combine(_env.WebRootPath, "images", Guid.NewGuid() + file.FileName);

            //using (var stream = File.Create(path))
            //{
            //    await file.CopyToAsync(stream);
            //}
            //return path;


        }
    }
}
