using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class EmailRecuperarViewModel
    {
        [Required(ErrorMessage = "Debe ingresar su correo electrónico")]
        [EmailAddress(ErrorMessage = "El dato ingresado debe ser un correo electrónico")]
        public string Email { get; set; }
    }
}