using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using _48_Najot_TalimApi.MyRepository.CourseCrud;
using Npgsql;

namespace _48_Najot_TalimApi.MyServises.CourseSrv
{
    public class CourseSrv : ICourseSrv
    {
        public Icourse _course;
        public IConfiguration _configuration;
        public int num = 0;
        public CourseSrv(Icourse icourse, IConfiguration configuration)
        {
            _course = icourse;
            _configuration = configuration;

        }
        public string CreateCourse(CourseDTO courseDTO)
        {
            try
            {
                if (courseDTO == null || courseDTO.name == "" || courseDTO.teacher_id < 0)
                {
                    return "Server Error Course";
                }
                _course.Create(courseDTO);
                return "Done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteById(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    string query = "select * from Courses";



                    NpgsqlCommand command = new NpgsqlCommand(query, connection);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        num = 0;
                        if ((reader.GetInt32(0) == id))
                        {
                            num = 1;
                            _course.Delete(id);

                        }
                    }
                    if (num == 1)
                    {
                        return "Malumot qabul qilindi";
                    }
                    else
                    {
                        return "Malumot topilmadi";
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }


        public CourseModel GetById(int id)
        {

            if (id < 0)
            {
                return new CourseModel();
            }
            try
            {
                return (CourseModel)_course.GetId(id);
            }
            catch
            {
                return new CourseModel();
            }
        }

        public string UpdateCourse(CourseDTO courseDTO, int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    string query = "select * from Courses";



                    NpgsqlCommand command = new NpgsqlCommand(query, connection);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        num = 0;
                        if ((reader.GetInt32(0) == id))
                        {
                            num = 1;
                            _course.Update(courseDTO,id);

                        }
                    }
                    if (num == 1)
                    {
                        return "Malumot qabul qilindi";
                    }
                    else
                    {
                        return "Malumot topilmadi";
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

    

