using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary.Models
{
    public class Sessions
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("available_capacity")]
        public string AvailabeSlots { get; set; }

        [JsonProperty("slots")]
        public string[] Slots { get; set; }

        [JsonProperty("vaccine")]
        public string Vaccine { get; set; }

        [JsonProperty("min_age_limit")]
        public string MinimumAgeLimit { get; set; }
    }
}
