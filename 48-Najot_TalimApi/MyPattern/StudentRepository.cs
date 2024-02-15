using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Diagnostics;
using System.Xml.Linq;

namespace _48_Najot_TalimApi.MyPattern
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
                    string query = "Insert into students(full_name,age,course_id,phone,parent_phone,shot_number) values(@full_name,@age,@course_id,@phone,@parent_phone,@shot_number)";

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

        public IEnumerable<Student> GetAllStudents()
        {
            
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "Select * from Students";

                    var result =  connection.Query<Student>(query);
                    return result;
                }
            
        }


        public bool DeleteStudent(int id)
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = $"Delete From Students where Student_id = {id}";

                var result = connection.Query<Student>(query);
                 if(result == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        public Student GetByIdStudent(int id) 
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = $"Select * from Students where student_id = {id}";

                var result = connection.Query<Student>(query);

                return (Student)result;
            }
        }

        public Student UpdateStudent(int id, StudentDTO studentDTO)
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = $"update Students set full_name = {studentDTO.full_name}, age = {studentDTO.age}, course_id = {studentDTO.course_id}" +
                    $"phone = {studentDTO.phone}, parent_phone = {studentDTO.parent_phone} where student_id = {id}";

                var result = connection.Query<Student>(query);
                return (Student)result;
            }
        }
    }
}
