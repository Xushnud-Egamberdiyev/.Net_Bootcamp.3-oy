using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;

namespace _48_Najot_TalimApi.MyRepository.StudentCrud
{
    public interface Istudent
    {
        public string Create(StudentDTO studentDTO);
        public IEnumerable<StudentModel> GetAll();

        public StudentModel GetByIDStudents(int id);
        public string Delete(int id);
        public string Update(int id, StudentDTO studentDTO);
    }
}
