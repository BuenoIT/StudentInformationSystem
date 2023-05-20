using StudentInformationSystem.API.DataModels;

namespace StudentInformationSystem.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>>GetGendersAsync();
    }
}
