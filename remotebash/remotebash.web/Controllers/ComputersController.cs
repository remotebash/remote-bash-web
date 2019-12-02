using System;
using System.Collections.Generic;
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
    public class ComputersController : Controller
    {

        private readonly IRequestLaboratory client;

        public ComputersController(IRequestLaboratory client)
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            long id = 0;
            try
            {
                id = int.Parse(HttpContext.Request.Query["lab"]);
            }
            catch { }

            string json = HttpContext.Session.GetString(Constants.USER);
            if (string.IsNullOrWhiteSpace(json))
            {
                return RedirectToAction("Index", "Auth");
            }


            var user = JsonConvert.DeserializeObject<User>(json);

            var lab = client.Get(user.Id, id);

            if(lab == null) return RedirectToAction("Index", "Auth");

            return View(lab);
        }
    }
}