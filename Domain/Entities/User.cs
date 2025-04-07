using Domain.Exceptions;

namespace Domain.Entities
{
    public class User
    {
        public Guid IdUser { get; private set; } = Guid.NewGuid();
        public int IdRole { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime EnrollmentDate { get; private set; } = DateTime.Now;

        public virtual ICollection<UserSubject>UserSubjects { get; set; } = new List<UserSubject>();

        public User(string name, string email, int idRole)
        {
            //Validation
            if (string.IsNullOrEmpty(name))
                throw new DomainException($"{nameof(User)}.{nameof(this.Name)} can't be:{name}");

            if (string.IsNullOrEmpty(email))
                throw new DomainException($"{nameof(User)}.{nameof(this.Email)} can't be:{email}");

            if (idRole <= 0)
                throw new DomainException($"{nameof(User)}.{nameof(this.IdRole)} can't be:{idRole}");

            Email = email.Trim();
            Name = name.Trim();
            IdRole = idRole;
        }
    }
}
