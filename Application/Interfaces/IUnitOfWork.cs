using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<UserSubject> UserSubject { get; }
        IStudentSubjectsRepository StudentSubjectsRepository { get; }
        Task<int> CompleteAsync();
    }
}
