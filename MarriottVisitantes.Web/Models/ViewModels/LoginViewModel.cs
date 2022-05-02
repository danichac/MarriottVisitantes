using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}