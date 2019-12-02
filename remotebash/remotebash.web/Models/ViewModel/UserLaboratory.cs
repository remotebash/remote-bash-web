using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Models.ViewModel
{
    public class UserLaboratory
    {
        public User User { get; set; }
        public List<Laboratory> Laboratories { get; set; }

    }
}
