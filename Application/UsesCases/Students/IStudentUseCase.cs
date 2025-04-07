using Application.DTOs;

namespace Application.UsesCases.Students
{
    public interface IStudentUseCase
    {
        Task<ResponseBaseDTO> AddAsync(CreateStudentDTO student);
        Task<ResponseBaseDTO> DeleteAsync(Guid id);
        Task<ResponseDTO<ResponseStudentDTO>> GetByIdAsync(Guid id);
    }
}
