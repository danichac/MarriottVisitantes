using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class UsuarioCreacionViewModel : UsuarioCreacionDTO
    {
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Required(ErrorMessage = "El primer nombre es requerido")]
        public string PrimerNombre { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string SegundoNombre { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Required(ErrorMessage = "El primer apellido es requerido")]   
        public string PrimerApellido { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string SegundoApellido { get; set; }

        [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Correo con formato incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MinLength(8, ErrorMessage = "La contraseña debe ser de al menos 8 caracteres")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, número y caracter especial")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña no coincide")]
        [MinLength(8, ErrorMessage = "La contraseña debe ser de al menos 8 caracteres")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, número y caracter especial")]
        public string PasswordConfirm { get; set; }
        public string Rol { get; set; }
    }
}