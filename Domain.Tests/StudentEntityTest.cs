using Domain.Entities;

namespace Domain.Tests
{
    public class StudentEntityTest
    {
        [Fact]
        internal async Task CreateStudent_WithOutName()
        {
            string message = string.Empty;
            try
            {
                Student student = new Student(name: string.Empty, email: "carlos@perez.com"
                    , idRole: 1);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.Equal(message, "User.Name can't be:");
        }

        [Fact]
        internal async Task CreateStudent_WithOutEmail()
        {
            string message = string.Empty;
            try
            {
                Student student = new Student(name: "Carlos", email: string.Empty
                    , idRole: 1);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.Equal(message, "User.Email can't be:");
        }
    }
}
