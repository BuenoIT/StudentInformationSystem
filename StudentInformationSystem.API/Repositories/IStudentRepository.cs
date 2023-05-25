using StudentInformationSystem.API.DataModels;

namespace StudentInformationSystem.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>>GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, DataModels.Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
    }
}
