using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Models
{
    public class ResponseModel<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public IEnumerable<ErrorModel> Errors { get; set; }
    }
}
