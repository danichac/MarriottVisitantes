

using System.Threading.Tasks;
using MarriottVisitantes.Dominio.Identidad;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IServicioEmail
    {
        Task<bool> EnviarEmailReemplazoPassword(string email);
    }
}