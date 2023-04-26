using StudentInformationSystem.API.DataModels;

namespace StudentInformationSystem.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
