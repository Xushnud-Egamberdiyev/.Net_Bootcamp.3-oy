using _48_Najot_TalimApi.MyRepository.CourseCrud;
using _48_Najot_TalimApi.MyRepository.StudentCrud;
using _48_Najot_TalimApi.MyServises.CourseSrv;
using _48_Najot_TalimApi.MyServises.StudentSrv;

namespace _48_Najot_TalimApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<Istudent, Student>();
            builder.Services.AddScoped<Icourse, Course>();

            builder.Services.AddScoped<IStudentSrv, StudentSrv>();
            builder.Services.AddScoped<ICourseSrv, CourseSrv>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
