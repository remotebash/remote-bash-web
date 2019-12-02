using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Models
{
    public class Command
    {
        [JsonProperty("idCommand")]
        public string IdCommand { get; set; }

        [JsonProperty("idComputer")]
        public long IdComputer { get; set; }

        [JsonProperty("operationalSystem")]
        public string OperationalSystem { get; set; }

        [JsonProperty("command")]
        public string CommandToExecute { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime? End { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("isExecuted")]
        public bool IsExecuted { get; set; }
    }
}
