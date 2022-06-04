using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class PasswordRecuperacionViewModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar su nueva contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe ingresar la confirmación")]
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
        public string PasswordConfirm { get; set; }
    }
}