

using cw3.DTOs.Requests;

namespace cw3.Controllers
{
    public interface IStudentDbService
    {
        void EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(int semester, string studies);
    }
}