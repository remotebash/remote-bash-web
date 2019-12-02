using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Models
{
    public class Computer
    {
        public string HdTotal { get; set; }
        public string HdUsage { get; set; }
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Macaddress { get; set; }
        public string OperationalSystem { get; set; }
        public string Platform { get; set; }
        public string ProcessorBrand { get; set; }
        public string ProcessorModel { get; set; }
        public string RamMemory { get; set; }
    }
}
