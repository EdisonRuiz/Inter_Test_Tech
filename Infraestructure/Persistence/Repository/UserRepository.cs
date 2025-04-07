using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repository
{
    public class UserRepository : IStudentSubjectsRepository
    {
        protected readonly DbContext _context;

        public UserRepository(DbContext context) => _context = context;

        public async Task<IList<Subject>> GetAllByIdAsync(Guid id)
        {
            var query = from s in _context.Set<Subject>()
                        join ss in _context.Set<UserSubject>() on s.Id equals ss.IdSubject                       
                        where s.UserSubjects.Any(u => u.IdUser == id)                        
                        select s;
            return await query.ToListAsync();
        }

        public async Task<IList<Subject>> GetAllSubjectsByIdAsync() => await _context.Set<Subject>()
                .Include(s => s.UserSubjects)
                .ThenInclude(u => u.User)
                .ToListAsync();

        public Task<Subject> GetByCodeAsync(string code) => _context.Set<Subject>()
                .Include(s => s.UserSubjects)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(s => s.Code == code);

        public async Task<bool> IsExistAsync(string name, string email) => await _context.Set<User>()
            .AnyAsync(u => u.Name == name || u.Email == email);
    }
}
