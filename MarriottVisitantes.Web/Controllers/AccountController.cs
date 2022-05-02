using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace MarriottVisitantes.Web.Controllers
{
    public class AccountController: Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<Usuario> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}