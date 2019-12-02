using remotebash.web.Models;
using remotebash.web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services
{
    public class RequestComputer : IRequestComputer
    {
        private readonly IRequestBase<Computer> requestBase;

        public RequestComputer(IRequestBase<Computer> requestBase)
        {
            this.requestBase = requestBase;
        }

        public Computer GetById(long id)
        {
            return requestBase.SendGetPathVariableAsync("/search/computers/", id.ToString());
        }
    }
}
