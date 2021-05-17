using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary.Models
{
    public class GenerateOTPResponse
    {
        [JsonProperty("txnId")]
        public string TransactionId { get; set; }

        public string Message { get; set; }
    }
}
