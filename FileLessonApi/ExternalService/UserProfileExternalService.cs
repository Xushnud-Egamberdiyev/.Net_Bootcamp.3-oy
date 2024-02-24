namespace FileLessonApi.ExternalService
{
    public class UserProfileExternalService
    {
        private readonly IWebHostEnvironment _env;

        public UserProfileExternalService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public UserProfileExternalService()
        {

        }

        public async Task<string> AddPictureAnGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Guid.NewGuid() + file.Name);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return path;

        }
    }
}
