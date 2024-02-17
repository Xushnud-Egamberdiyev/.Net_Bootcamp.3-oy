using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using Dapper;
using Npgsql;

namespace _48_Najot_TalimApi.MyRepository.StudentCrud
{
    public class Student : Istudent
    {
        public IConfiguration _config;
        public Student(IConfiguration config)
        {
            _config = config;
        }
        public string Create(StudentDTO studentDTO)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = $"Insert into students(full_name,age,course_id,phone,parent_phone,shot_number) values(@full_name,@age,@course_id,@phone,@parent_phone,@shot_number)";

                    var parametrs = new StudentDTO
                    {
                        full_name = studentDTO.full_name,
                        age = studentDTO.age,
                        course_id = studentDTO.course_id,
                        parent_phone = studentDTO.parent_phone,
                        phone = studentDTO.phone,
                        shot_number = studentDTO.shot_number,
                    };
                    connection.Execute(query, parametrs);
                }
                return "Malumot yaratildi";
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
                using(NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Delete from students where Student_id = @idd";

                    connection.Execute(query, new { idd = id });

                    return "Succesfully";
                }
                
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<StudentModel> GetAll()
        {
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "Select * from Students";

                    IEnumerable<StudentModel> result = connection.Query<StudentModel>(query);
                    return result;
                }
            }
            catch 
            {
                return Enumerable.Empty<StudentModel>();
            }

        }

        public StudentModel GetByIDStudents(int id)
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = "Select * from Students where student_id = @id";

                var result = connection.QueryFirstOrDefault<StudentModel>(query, new { id });

                return result;
            }
        }

        public string Update(int id, StudentDTO studentDTO)
        {
            try { 
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = "Update students set full_name = @full_name, age = @age, course_id = @course_id, phone = @phone, parent_phone = @parent_phone, shot_number = @shot_number" +
                    "where id = @id";

                connection.Execute(query, new
                {
                    full_name = studentDTO.full_name,
                    age = studentDTO.age,
                    course_id = studentDTO.course_id,
                    phone = studentDTO.phone,
                    parent_phone = studentDTO.parent_phone,
                    shot_number = studentDTO.shot_number,
                });

                    return "Succesfully";
                }
            }
            catch
            {
                return "ERROR";
            }
        }
    }
}
