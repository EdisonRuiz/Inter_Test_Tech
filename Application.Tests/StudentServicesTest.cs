using Domain.Entities;
using Moq;

namespace Application.Tests
{
    public class StudentServicesTest
    {
        //private readonly Mock<IStudentRepository> _mockRepo;
        //private readonly StudentService _studentService;

        public StudentServicesTest()
        {
            ////Mock
            //_mockRepo = new Mock<IStudentRepository>();
            //_studentService = new StudentService(_mockRepo.Object);
        }

        //[Fact]
        //public async Task CreateStudent_WouldSaveEndReturnStudent()
        //{
        //    Student student = new Student(name: "Carlos", email: "carlos@perez.com", enrollmentDate: DateTime.Now);

        //    _mockRepo.Setup(r => r.AddAsync(student)).ReturnsAsync(student);
        //    Student response = await _studentService.AddAsync(student);

        //    Assert.Equal("Carlos", response.Name);
        //    _mockRepo.Verify(r => r.AddAsync(student), Times.Once);
        //} 
    }
}