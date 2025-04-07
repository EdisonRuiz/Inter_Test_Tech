using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
using Application.Utility;

namespace Application.UsesCases.Students
{
    public class StudentUseCase : IStudentUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBaseDTO> AddAsync(CreateStudentDTO student)
        {
            //Validation Rules
            bool isExist = await _unitOfWork.StudentSubjectsRepository.IsExistAsync(student.Name, student.Email);
            if (isExist)
                return new ResponseBaseDTO() { StatusCode = 400, Message = "Usuario ya ha sido creado, cada usuario debe tener un email diferente por cuenta" };

            Student entity = new Student(student.Name, student.Email, (byte)EnumsApp.Student);
            await _unitOfWork.Users.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return new ResponseBaseDTO() { StatusCode = 200, Message = entity.IdUser.ToString() };
        }

        public async Task<ResponseBaseDTO> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseBaseDTO() { StatusCode = 400, Message = "Id no puede ser vacio" };

            User entity = await _unitOfWork.Users.GetByIdAsync(id);
            if (entity == null && entity.IdRole != (byte)EnumsApp.Student)
                return new ResponseBaseDTO() { StatusCode = 404, Message = "Usuario no encontrado" };
            await _unitOfWork.Users.DeleteAsync(entity);
            await _unitOfWork.CompleteAsync();
            return new ResponseBaseDTO() { StatusCode = 200, Message = "Usuario eliminado" };
        }

        public async Task<ResponseDTO<ResponseStudentDTO>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseDTO<ResponseStudentDTO>() { StatusCode = 400, Message = "Id no puede ser vacio" };

            User entity = await _unitOfWork.Users.GetByIdAsync(id);

            if (entity == null)
                return new ResponseDTO<ResponseStudentDTO>() { StatusCode = 404, Message = "Usuario no encontrado" };

            return new ResponseDTO<ResponseStudentDTO>()
            {
                StatusCode = 200,
                Message = "Usuario encontrado",
                Data = new ResponseStudentDTO()
                {
                    IdUser = entity.IdUser,
                    Name = entity.Name,
                    Email = entity.Email
                }
            };
        }
    }
}
