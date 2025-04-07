using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateStudentDTO
    {
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Nombre no puede exceder los 50 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Correo electronico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo incorrecto")]
        public string Email { get; set; } = string.Empty;
    }
}
