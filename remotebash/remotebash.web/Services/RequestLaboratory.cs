using remotebash.web.Models;
using remotebash.web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services
{
    public class RequestLaboratory : IRequestLaboratory
    {
        private readonly IRequestBase<Laboratory> requestBase;

        public RequestLaboratory(IRequestBase<Laboratory> requestBase)
        {
            this.requestBase = requestBase;
        }

        public Laboratory Get(long userId, long labId)
        {
            var lab = requestBase.SendGetPathVariableAsync("/search/laboratories/", labId.ToString());

            if(lab != null)
            {
                if(lab.User != null)
                {
                    return lab.User.Id == userId ? lab : null;
                }
            }

            return null;
        }

        public List<Laboratory> GetAll(long userId)
        {
            var labs = requestBase.SendGetAll("/search/laboratories/");
            return labs.Where(obj => obj.User != null ? obj.User.Id == userId ? true : false : false).ToList();
        }

        public string Register(Laboratory user)
        {
            return requestBase.SendPostReturnStringAsync("/register/users/", user);
        }
    }
}
