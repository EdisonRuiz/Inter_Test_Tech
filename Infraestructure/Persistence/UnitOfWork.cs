using Domain.Entities;
using Application.Interfaces;
using Infraestructure.Persistence.Repository;

namespace Infraestructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestInterContext _context;

        private IRepository<User> _users;
        private IRepository<Subject> _subjects;
        private IRepository<UserSubject> _userSubject;
        private IStudentSubjectsRepository _studentSubjectsRepository;

        public UnitOfWork(TestInterContext context) => _context = context;

        public IRepository<User> Users => _users ??= new Repository<User>(_context);

        public IStudentSubjectsRepository StudentSubjectsRepository => _studentSubjectsRepository ??= new UserRepository(_context);

        public IRepository<Subject> Subjects => _subjects ??= new Repository<Subject>(_context);

        public IRepository<UserSubject> UserSubject => _userSubject ??= new Repository<UserSubject>(_context);

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
