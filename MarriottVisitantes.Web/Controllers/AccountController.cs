using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using MarriottVisitantes.Web.Models.ViewModels;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Dominio.Identidad;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Web.Controllers
{
    public class AccountController: Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IServicioUsuarios _servicio;

        public AccountController(ILogger<AccountController> logger,
            IServicioUsuarios servicio)
        {
            _logger = logger;
            _servicio = servicio;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnURL = "")
        {
            if(ModelState.IsValid)
            {
                var ingresoExitoso = await _servicio.IngresarAsync(model.Email, model.Password, model.RememberMe);

                if(ingresoExitoso)
                {
                    if(!string.IsNullOrEmpty(returnURL))
                        return Redirect(returnURL);
                    else
                        return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Datos", "Datos de inicio de sesión incorrectos");
                
                model.Email = "";
                model.Password = "";
            }
            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _servicio.SalirAsync();

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public async Task<IActionResult> Editar()
        {
            try 
            {
                var usuario = await _servicio.ObtenerUsuarioIngresadoAsync();
                var model = new UsuarioEdicionViewModel(usuario);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en editar usuario.");
                return RedirectToAction("Error", "Home");
            } 
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioEdicionViewModel model)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    var usuario = await _servicio.ObtenerUsuarioIngresadoAsync();
                    var contrasenaAnteriorCorrecta = _servicio.VerificarContrasena(usuario, model.PasswordOld);

                    var emailExiste = await _servicio.EmailExiste(model.Email);
                    var userNameExiste = await _servicio.UserNameExiste(model.UserName);

                    if(!contrasenaAnteriorCorrecta)
                    {
                        ModelState.AddModelError("PasswordOld", "La contraseña no coincide");
                    }
                    if(userNameExiste && model.UserName != usuario.UserName)
                        ModelState.AddModelError("UserName", "El nombre de usuario ingresado ya es utilizado por otro usuario.");
                    if(emailExiste && model.Email != usuario.Email)
                        ModelState.AddModelError("Email", "El correo electrónico ingresado ya es utilizado por otro usuario.");

                    if(ModelState.IsValid)
                    {
                        usuario.Actualizar(model);
                        var creacionResultado = await _servicio.ActualizarAsync(usuario);
                        if(creacionResultado.Succeeded)
                        {
                            ViewData["Éxito"] = "Datos actualizados";
                        }
                        else
                        {
                            throw new Exception("Error actualizando los datos");
                        }
                            
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en editar usuario.");
                return RedirectToAction("Error", "Home");
            } 
        }
    }
}