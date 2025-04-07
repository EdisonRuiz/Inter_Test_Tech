using Domain.Exceptions;

namespace Domain.Entities
{
    public class UserSubject
    {
        public int Id { get; private set; }
        public Guid IdUser { get; private set; }
        public Guid IdSubject { get; private set; }

        public virtual User User { get; private set; }
        public virtual Subject Subject { get; private set; }

        public UserSubject(Guid idUser, Guid idSubject)
        {
            if(idUser.Equals(Guid.Empty))
                throw new DomainException($"{nameof(User)}.{nameof(this.IdUser)} can't be: {idUser}");

            if (idUser.Equals(Guid.Empty))
                throw new DomainException($"{nameof(User)}.{nameof(this.IdSubject)} can't be: {idSubject}");

            IdUser = idUser;
            IdSubject = idSubject;
        }
    }
}
