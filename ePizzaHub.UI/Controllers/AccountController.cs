﻿using ePizzaHub.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;

        public AccountController(IAuthService authService)
        {
                _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVeiwModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = _authService.ValidateUser(model.Email, model.Password);
                if (userModel != null) 
                { 

                }
            }
            
            return View();
        }
    }
}
