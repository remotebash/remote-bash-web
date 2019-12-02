using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using remotebash.web.Utils;

namespace remotebash.web.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove(Constants.USER);
            ViewData["UserConnect"] = "";
            return RedirectToAction("Index", "Auth");
        }
    }
}