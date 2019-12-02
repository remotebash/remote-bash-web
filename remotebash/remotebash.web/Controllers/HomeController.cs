using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using remotebash.web.Models;
using remotebash.web.Models.ViewModel;
using remotebash.web.Services;
using remotebash.web.Services.Interface;
using remotebash.web.Utils;

namespace remotebash.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestLaboratory client;

        public HomeController(IRequestLaboratory client)
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            string json = HttpContext.Session.GetString(Constants.USER);

            if (string.IsNullOrWhiteSpace(json))
            {
                return RedirectToAction("Index", "Auth");
            }

            return View(GetUserLaboratory(json));
        }

        private UserLaboratory GetUserLaboratory(string json)
        {
            var user = JsonConvert.DeserializeObject<User>(json);
            var labs = client.GetAll(user.Id);

            UserLaboratory userLaboratory = new UserLaboratory();
            userLaboratory.User = user;
            userLaboratory.Laboratories = labs;
            return userLaboratory;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
