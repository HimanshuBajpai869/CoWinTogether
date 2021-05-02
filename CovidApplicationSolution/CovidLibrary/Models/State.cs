using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary.Models
{
    public class State
    {
        [JsonProperty("state_id")]
        public string StateId { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }
    }
}
