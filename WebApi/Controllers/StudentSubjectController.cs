using Application.DTOs;
using Application.UsesCases.StudentSubjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSubjectUseCase _useCase;

        public StudentSubjectController(IStudentSubjectUseCase useCase) => _useCase = useCase;

        // GET api/<StudentSubject>/315AFCC2-564E-4C9A-9F26-32C4DEA258F1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(Guid id) => Ok(await _useCase.GetAllByIdAsync(id));

        [HttpPut()]
        public async Task<IActionResult> AssingSubject([FromBody] AssingSubjectDTO model)
            => Ok(await _useCase.AssingSubjectAsync(model));
    }
}
