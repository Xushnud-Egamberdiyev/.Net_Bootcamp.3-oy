using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Npgsql;

namespace _48_Najot_TalimApi.MyRepository.CourseCrud
{
    public class Course : Icourse
    {
        public IConfiguration _config;
        public Course(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string Create(CourseDTO courseDTO)
        {
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Insert into courses(name, teacher_id, duration, price, description, student_count)" +
                        "values(@name, @teacher_id, @duration, @price, @description, @student_count)";

                    var paramets = new CourseDTO
                    {
                        name = courseDTO.name,
                        teacher_id = courseDTO.teacher_id,
                        duration = courseDTO.duration,
                        price = courseDTO.price,
                        description = courseDTO.description,
                        student_count = courseDTO.student_count,
                    };

                    connection.Execute(query, paramets);

                    return "Malumot yaratildi";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
        
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {

                    string query = "Delete from Courses where course_id = @idd";

                    connection.Execute(query, new { idd = id });

                    return "Malumot ochirildi";

                }
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<CourseModel> GetAll()
        {
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Select * from Courses";

                    IEnumerable<CourseModel> result = connection.Query<CourseModel>(query);

                    return result;
                }
            }
            catch
            {
                return Enumerable.Empty<CourseModel>();
            }
        }

        public CourseModel GetId(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Select * from Courses where course_id = @idd";

                    var result = connection.Query<CourseModel>(query, new { idd = id }).ToList();

                    return result[0];
                }
            }
            catch
            {
                return new CourseModel();
            }
        }

        public string Update(CourseDTO courseDTO, int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Update Courses set name = @name, teacher_id = @teacher_id, duration = @duration, price = @price, description = @description, student_count = @student_count";

                    var parametrs = new CourseDTO
                    {
                        name = courseDTO.name,
                        teacher_id = courseDTO.teacher_id,
                        duration = courseDTO.duration,
                        price = courseDTO.price,
                        description = courseDTO.description,
                        student_count = courseDTO.student_count,
                    };

                    connection.Execute(query, parametrs);

                    return "Malumot ozgartirildi";
                }
            }
            catch (Exception ex) { return ex.Message; }
            
        }
    }
}
