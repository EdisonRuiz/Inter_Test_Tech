
namespace Domain.Entities
{
    public class Student : User
    {
        
        public Student(string name, string email, int idRole) : base(name, email, idRole)
        {
        }
    }
}
