using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentSubjectsRepository
    {
        Task<bool> IsExistAsync(string name, string email);
        Task<IList<Subject>> GetAllByIdAsync(Guid id);
        Task<IList<Subject>> GetAllSubjectsByIdAsync();
        Task<Subject> GetByCodeAsync(string code);
    }
}
