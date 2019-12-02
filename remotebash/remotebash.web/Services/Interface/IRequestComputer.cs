using remotebash.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services.Interface
{
    public interface IRequestComputer
    {
        Computer GetById(long id);
    }
}
