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
            var settings = new EmailClientSettings(_config);

            var linkRecuperacion = await ObtenerLinkRecuperacion(email);

            if(linkRecuperacion == "Usuario no encontrado")
                return false;

            var mensaje = GenerarMensaje(linkRecuperacion);
 
            MailMessage message = new MailMessage();
            message.From = new MailAddress(settings.EmailAddress);
            message.Subject = "Reestablecer contraseña";
            message.To.Add(new MailAddress(email));
            message.Body ="<html><body> " + mensaje + " </body></html>";
            message.IsBodyHtml = true;
 
            var smtpClient = new SmtpClient(settings.Host)
            {
                Port = settings.Port,
                Credentials = new NetworkCredential(settings.EmailAddress, settings.Password),
                EnableSsl = true,
            };
            smtpClient.Send(message);

            return true;
        }

        private async Task<string> ObtenerLinkRecuperacion( string email)
        {
            var usuario = await _gestorUsuarios.FindByEmailAsync(email);

            if(usuario is null)
                return "Usuario no encontrado";
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

        private class EmailClientSettings
        {
            public EmailClientSettings(IConfiguration config)
            {
                EmailAddress = config.GetSection("EmailSettings:EmailAddress").Value;
                Password = config.GetSection("EmailSettings:Password").Value;
                Host = config.GetSection("EmailSettings:Host").Value;
                Port = Convert.ToInt32(config.GetSection("EmailSettings:Port").Value);
            }

            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
        }
    }
}