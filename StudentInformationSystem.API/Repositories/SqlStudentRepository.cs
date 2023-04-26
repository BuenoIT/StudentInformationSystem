using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.API.DataModels;

namespace StudentInformationSystem.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentDbContext context;

        public SqlStudentRepository(StudentDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
