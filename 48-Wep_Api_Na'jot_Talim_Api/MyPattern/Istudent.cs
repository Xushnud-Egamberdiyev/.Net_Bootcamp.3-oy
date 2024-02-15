using _48_Wep_Api_Na_jot_Talim_Api.DTO;
using _48_Wep_Api_Na_jot_Talim_Api.Models;

namespace _48_Wep_Api_Na_jot_Talim_Api.MyPattern
{
    public interface Istudent
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);
        public bool DeleteStudent(int id);
        public Student UpdateStudent(int id, StudentDTO studentDTO);
    }
}
