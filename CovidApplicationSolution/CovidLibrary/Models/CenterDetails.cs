using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary.Models
{
    public class CenterDetails
    {
        [JsonProperty("centers")]
        public Center[] Centers { get; set; }
    }
}
