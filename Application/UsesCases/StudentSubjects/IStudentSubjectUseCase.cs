using Application.DTOs;

namespace Application.UsesCases.StudentSubjects
{
    public interface IStudentSubjectUseCase
    {
        Task<ResponseBaseDTO> AssingSubjectAsync(AssingSubjectDTO code);
        Task<ResponseDTO<IList<ResponseSubject>>> GetAllByIdAsync(Guid id);
    }
}
