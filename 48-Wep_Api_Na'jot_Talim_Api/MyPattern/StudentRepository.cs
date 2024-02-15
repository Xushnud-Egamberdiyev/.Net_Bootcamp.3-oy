using _48_Wep_Api_Na_jot_Talim_Api.DTO;
using _48_Wep_Api_Na_jot_Talim_Api.Models;
using Dapper;
using Npgsql;

namespace _48_Wep_Api_Na_jot_Talim_Api.MyPattern
{
    public class StudentRepository : Istudent
    {
        private readonly IConfiguration _configuration;
        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public string CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "Insert into students(full_name,age,course_id,phone,parent_phome,shot_number) values(@full_name,@age,@course_id,@phone,@parent_phome,@shot_number)";

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
                return "Malumot Yaratildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetByIdStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
