using Application.DTOs;
using Application.UsesCases.Students;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentUseCase _useCase;

        public StudentsController(IStudentUseCase useCase) => _useCase = useCase;

        // GET api/<Students>/315AFCC2-564E-4C9A-9F26-32C4DEA258F1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _useCase.GetByIdAsync(id));

        // POST api/<Students>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentDTO model) 
            => Ok(await _useCase.AddAsync(model));


        // DELETE api/<Students>/315AFCC2-564E-4C9A-9F26-32C4DEA258F1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await _useCase.DeleteAsync(id));
    }
}
