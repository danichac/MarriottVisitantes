
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class VisitasPaginacionViewModel
    {
        public VisitasPaginacionViewModel(VisitasPaginacionDTO terminadas, VisitasPaginacionDTO noTerminadas)
        {
            VisitasTerminadas = terminadas;
            VisitasNoTerminadas = noTerminadas;
        }
        public VisitasPaginacionDTO VisitasTerminadas { get; set; }
        public VisitasPaginacionDTO VisitasNoTerminadas { get; set; }
    }
}