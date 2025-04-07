using Application.DTOs;
using Application.Interfaces;
using Application.Utility;
using Domain.Entities;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.UsesCases.StudentSubjects
{
    public class StudentSubjectUseCase : IStudentSubjectUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentSubjectUseCase(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ResponseBaseDTO> AssingSubjectAsync(AssingSubjectDTO request)
        {
            if (request is not null && string.IsNullOrEmpty(request.Code) && request.IdUser != Guid.Empty)
            {
                return new ResponseBaseDTO { StatusCode = 400, Message = "El código de la materia no puede estar vacío, y debe haber un estudiante seleccionado" };
            }

            var subject = await _unitOfWork.StudentSubjectsRepository.GetByCodeAsync(request.Code);

            if (subject is null)
            {
                return new ResponseBaseDTO { StatusCode = 404, Message = "Materia no encontrada" };
            }

            var student = await _unitOfWork.Users.GetByIdAsync(request.IdUser);

            if (student is null || student.IdRole != (byte)EnumsApp.Student)
            {
                return new ResponseBaseDTO { StatusCode = 404, Message = "Usuario no encontrado" };
            }

            var selectedSubjects = await _unitOfWork.StudentSubjectsRepository.GetAllByIdAsync(student.IdUser);

            if (selectedSubjects.GroupBy(x => x.Id).ToList().Count >= 3)
            {
                return new ResponseBaseDTO { StatusCode = 400, Message = "El estudiante ya tiene 3 materias asignadas" };
            }

            if (selectedSubjects.Any(s => s.Code.Trim() == subject.Code.Trim()))
            {
                return new ResponseBaseDTO { StatusCode = 400, Message = "El estudiante ya tiene esta materia asignada" };
            }

            await _unitOfWork.UserSubject.AddAsync(new UserSubject(student.IdUser, subject.Id));
            await _unitOfWork.CompleteAsync();
            return new ResponseBaseDTO { StatusCode = 200, Message = "Materia asignada al estudiante" };
        }

        public async Task<ResponseDTO<IList<ResponseSubject>>> GetAllByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null || user.IdRole != (byte)EnumsApp.Student)
            {
                return new ResponseDTO<IList<ResponseSubject>> { StatusCode = 404, Message = "Usuario no encontrado" };
            }

            var selectedSubjects = await _unitOfWork.StudentSubjectsRepository.GetAllByIdAsync(id);
            var allSubjects = await _unitOfWork.StudentSubjectsRepository.GetAllSubjectsByIdAsync();

            var selectedSubjectCodes = new HashSet<string>(selectedSubjects.Select(s => s.Code.Trim()));

            var responseData = allSubjects.Select(subject =>
            {
                var isSelected = selectedSubjectCodes.Contains(subject.Code.Trim());
                var teacherName = subject.UserSubjects
                                         .Where(t => t.User.IdRole == (byte)EnumsApp.Teacher)
                                         .Select(t => t.User.Name)
                                         .FirstOrDefault();

                return new ResponseSubject
                {
                    Code = subject.Code.Trim(),
                    Name = subject.Name.Trim(),
                    Credits = subject.Credits,
                    IsSelected = isSelected,
                    Teacher = teacherName
                };
            }).ToList();

            // Rule Validation
            responseData = FilterResponseData(responseData);

            // Add classmates
            responseData = responseData.Select(subject =>
            {
                var classmates = selectedSubjects
                    .Where(s => s.Code.Trim() == subject.Code.Trim())
                    .SelectMany(s => s.UserSubjects
                        .Where(u => u.User.IdRole == (byte)EnumsApp.Student)
                        .Select(u => u.User.Name))
                    .Distinct()
                    .ToList();
                subject.Classmates = classmates;
                return subject;
            }).ToList();

            return new ResponseDTO<IList<ResponseSubject>>
            {
                StatusCode = 200,
                Message = "Materias del usuario obtenidas",
                Data = responseData
            };
        }

        private List<ResponseSubject> FilterResponseData(List<ResponseSubject> data)
        {
            // Agrupar por Teacher
            var groupedByTeacher = data.GroupBy(x => x.Teacher);

            var result = new List<ResponseSubject>();

            foreach (var group in groupedByTeacher)
            {
                // Verificar si hay algún elemento seleccionado en el grupo
                var hasSelected = group.Any(x => x.IsSelected);

                if (hasSelected)
                {
                    // Añadir todos los seleccionados
                    result.AddRange(group.Where(x => x.IsSelected));

                    // Si solo hay uno seleccionado, no necesitamos añadir más
                    // Si hay varios seleccionados, ya están incluidos
                }
                else
                {
                    // Si no hay seleccionados, añadir todos los del grupo
                    result.AddRange(group);
                }
            }

            return result;
        }
    }
}
