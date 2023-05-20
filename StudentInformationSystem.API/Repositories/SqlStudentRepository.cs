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

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await context.Gender.ToListAsync();
        }
    }
}
