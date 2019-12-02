using remotebash.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services.Interface
{
    public interface IRequestLaboratory
    {
        List<Laboratory> GetAll(long userId);
        Laboratory Get(long userId, long labId);
        string Register(Laboratory user);
    }
}
