using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Correo con formato incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }    
        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}