using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.API.DomainModels;
using StudentInformationSystem.API.Repositories;

namespace StudentInformationSystem.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch single student detail
            var student = await studentRepository.GetStudentAsync(studentId);

            //Return student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
           if (await studentRepository.Exists(studentId))
            {
                var updateStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (updateStudent != null)
                {
                    return Ok(mapper.Map<Student>(updateStudent));
                }
            }
                return NotFound();
        }
    }
}
