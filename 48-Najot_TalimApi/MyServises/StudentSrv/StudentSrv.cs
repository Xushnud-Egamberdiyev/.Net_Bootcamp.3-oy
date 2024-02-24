

using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.MyRepository.StudentCrud;

namespace _48_Najot_TalimApi.MyServises.StudentSrv
{
    public class StudentSrv : IStudentSrv
    {
        public Istudent _istudent;
        public StudentSrv(Istudent istudent)
        {
            _istudent = istudent;
        }
        public string Create(StudentDTO studentDTO)
        {
            if (studentDTO == null || studentDTO.full_name == "" || studentDTO.shot_number == "")
            {
                return "Servise error Student null";
            }
            try
            {
                _istudent.Create(studentDTO);
                return "Cervise done";
            }
            catch
            {
                return "Error servise";
            }
        }

        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id error";
            }
            try
            {
                _istudent.Delete(id);
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Update(int id, StudentDTO studentDTO)
        {
            if (id > 0)
            {
                if (studentDTO.full_name == "")
                {
                    if (studentDTO != null)
                    {
                        return "Done";
                        _istudent.Update(id, studentDTO);
                    }
                }
            }
            return "Error";
        }
    }
}
