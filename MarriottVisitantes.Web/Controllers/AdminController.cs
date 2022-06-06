using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using MarriottVisitantes.Web.Utils;
using MarriottVisitantes.Web.Models.ViewModels;
using MarriottVisitantes.Servicios.Interfaces;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IServicioUsuarios _servicioUsuario;

        public AdminController(ILogger<AdminController> logger, IServicioUsuarios servicioUsuarios)
        {
            _logger = logger;
            _servicioUsuario = servicioUsuarios;
        }

        [Authorize(Roles = Constantes.RolAdministrador)]
        public IActionResult AgregarUsuario()
        {
            return View();
        }

        [Authorize(Roles = Constantes.RolAdministrador)]
        [HttpPost]
        public async Task<IActionResult> AgregarUsuario(UsuarioCreacionViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var emailExiste = await _servicioUsuario.EmailExiste(model.Email);
                    var userNameExiste = await _servicioUsuario.UserNameExiste(model.UserName);

                    if(userNameExiste)
                        ModelState.AddModelError("UserName", "El nombre de usuario ingresado ya existe");
                    if(emailExiste)
                        ModelState.AddModelError("Email", "El correo electrónico ingresado ya existe");

                    if(!userNameExiste && !emailExiste)
                    {
                        var creacionResultado = await _servicioUsuario.CrearAsync(model);
                        if(creacionResultado.Succeeded)
                        {
                            var usuarioCreado = await _servicioUsuario.BuscarPorEmailAsync(model.Email);
                            await _servicioUsuario.AgregarARol(usuarioCreado, model.Rol);
                            
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            return RedirectToAction("Error", "Home");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en AgregarUsuario");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
