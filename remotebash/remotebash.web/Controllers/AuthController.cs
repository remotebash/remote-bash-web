using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using remotebash.web.Models;
using remotebash.web.Services.Interface;
using remotebash.web.Utils;

namespace remotebash.web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRequestUser client;

        public AuthController(IRequestUser client)
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            string json = HttpContext.Session.GetString(Constants.USER);

            if (!string.IsNullOrWhiteSpace(json))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new ErrorModel());
        }

        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login([Bind("Email,Password")] User user)
        {
            try
            {
                User userSaved = client.Login(user);
                if(userSaved != null)
                {
                    HttpContext.Session.SetString(Constants.USER, JsonConvert.SerializeObject(userSaved));
                    return RedirectToAction("Index", "Home");
                    /*return new ResponseModel<User>
                    {
                        Data = userSaved,
                        Status = 200
                    };*/
                }
                else
                {
                    return View("Index", new ErrorModel { Id = 400, Message = "Login/Senha inválidos" });
                }
            }
            catch
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Register(User user, IFormCollection form)
        {
            string messages = string.Empty;

            if (user.Password != form["Password2"] || string.IsNullOrWhiteSpace(user.Password))
                messages += $"Senhas inválidas! ";

            if(string.IsNullOrWhiteSpace(user.Name))
                messages += $"Nome não pode ser vázio! ";

            if (string.IsNullOrWhiteSpace(user.Email))
                messages += $"Email não pode ser vázio! ";

            if(messages.Length > 0)
                return View("Index", new ErrorModel { Id = 400, Message = messages });

            return View();
        }
    }
}