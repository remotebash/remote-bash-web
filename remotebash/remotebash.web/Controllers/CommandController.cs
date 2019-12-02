using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using remotebash.web.Models;
using remotebash.web.Models.ViewModel;
using remotebash.web.Services.Interface;
using remotebash.web.Utils;

namespace remotebash.web.Controllers
{
    public class CommandController : Controller
    {

        private readonly IRequestLaboratory clientLab;
        private readonly IRequestComputer clientPc;

        public CommandController(IRequestComputer clientPc, IRequestLaboratory clientLab)
        {
            this.clientPc = clientPc;
            this.clientLab = clientLab;
        }

        public IActionResult Index()
        {
            long idLab = 0;
            long idPc = 0;
            try
            {
                idPc = int.Parse(HttpContext.Request.Query["pc"]);
                idLab = int.Parse(HttpContext.Request.Query["lab"]);
            }
            catch { }

            string json = HttpContext.Session.GetString(Constants.USER);
            if (string.IsNullOrWhiteSpace(json))
            {
                return RedirectToAction("Index", "Auth");
            }


            var user = JsonConvert.DeserializeObject<User>(json);

            var lab = clientLab.Get(user.Id, idLab);
            var pc = clientPc.GetById(idPc);

            if (pc == null) return RedirectToAction("Index", "Computers");
            if (!lab.ComputerSet.Any(obj => obj.Id == pc.Id)) if (pc == null) return RedirectToAction("Index", "Computers");

            UserComputer userComputer = new UserComputer();
            userComputer.User = user;
            userComputer.Computer = pc;

            return View(userComputer);
        }
    }
}