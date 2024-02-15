using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;

namespace _48_Najot_TalimApi.MyPattern
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
