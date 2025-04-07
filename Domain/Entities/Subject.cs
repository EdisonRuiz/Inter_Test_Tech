using Domain.Exceptions;

namespace Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public int Credits { get; private set; }

        public virtual ICollection<UserSubject> UserSubjects { get; set; } = new HashSet<UserSubject>();
        public Subject(string name, string code)
        {
            //Validations
            if (string.IsNullOrEmpty(name)) 
                throw new DomainException($"{nameof(Subject)}.{nameof(this.Name)} can't be:{name}");
            
            if (string.IsNullOrEmpty(code)) 
                throw new DomainException($"{nameof(Subject)}.{nameof(this.Code)} can't be: {code}");

            Name = name;
            Code = code;
            Credits = 3;
        }
    }
}
