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
    }
}