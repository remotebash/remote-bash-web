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
                idLab = int.Parse(HttpContext.Request.Query["lab"]);
                idPc = int.Parse(HttpContext.Request.Query["pc"]);
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

            if(idLab > 0 && idPc > 0)
            {
                if (pc == null) return RedirectToAction("Index", "Computers");
                if (!lab.ComputerSet.Any(obj => obj.Id == pc.Id)) if (pc == null) return RedirectToAction("Index", "Computers");
            }
            else
            {
                if (!(lab.User.Id == user.Id)) return RedirectToAction("Index", "Computers");
            }
            
            UserComputer userComputer = new UserComputer();
            userComputer.User = user;
            userComputer.Computer = pc ?? new Computer();
            userComputer.Laboratory = lab;
            userComputer.UrlRest = idLab > 0 && idPc == 0 ? "http://3.94.151.158:8082/register/command/laboratory" : "http://3.94.151.158:8082/register/command";

            return View(userComputer);
        }
    }
}