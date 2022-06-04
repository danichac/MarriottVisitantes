using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.Servicios.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Servicios.Implementaciones
{
    public class ServicioEmail : IServicioEmail
    {
        private readonly ILogger<ServicioEmail> _logger;
        private readonly UserManager<Usuario> _gestorUsuarios;
        private readonly IConfiguration _config;

        public ServicioEmail(ILogger<ServicioEmail> logger,
            UserManager<Usuario> gestorUsuarios,
            IConfiguration config)
        {
            _gestorUsuarios = gestorUsuarios;
            _logger = logger;
            _config = config;
        }

        public async Task<bool> EnviarEmailReemplazoPassword(string email)
        {
            var fromMail = _config.GetSection("EmailSettings:EmailAddress").Value;
            var fromPassword = _config.GetSection("EmailSettings:Password").Value;

            var linkRecuperacion = await ObtenerLinkRecuperacion(email);
            var mensaje = GenerarMensaje(linkRecuperacion);
 
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Reestablecer contraseña";
            message.To.Add(new MailAddress(email));
            message.Body ="<html><body> " + mensaje + " </body></html>";
            message.IsBodyHtml = true;
 
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);

            return true;
        }

        private async Task<string> ObtenerLinkRecuperacion( string email)
        {
            var usuario = await _gestorUsuarios.FindByEmailAsync(email);
            var token = await _gestorUsuarios.GeneratePasswordResetTokenAsync(usuario);

            token = HttpUtility.UrlEncode(token);

            var url = _config.GetSection("URL").Value + "Account/" + "RecuperarPassword";
            var link = url + "?Id=" + usuario.Id + "&token=" + token;

            return link;
        }

        private string GenerarMensaje(string link)
        {
            var mensaje = $"<p>Para reestablecer su contraseña haga click en <a href=\"{link}\">este enlace</a></p>";
            return mensaje;
        }
    }
}