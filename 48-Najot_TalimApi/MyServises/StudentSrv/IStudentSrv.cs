using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;

namespace _48_Najot_TalimApi.MyServises.StudentSrv
{
    public interface IStudentSrv
    {
        public string Create(StudentDTO studentDTO);
        public string Delete(int id);
        public string Update(int id, StudentDTO student);
    }
}
