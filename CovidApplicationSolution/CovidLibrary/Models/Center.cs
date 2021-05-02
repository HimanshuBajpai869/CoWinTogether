using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary.Models
{
    public class Center
    {
        [JsonProperty("center_id")]
        public string CenterId { get; set; }

        [JsonProperty("name")]
        public string CenterName { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("district_name")]
        public string DistrictName { get; set; }

        [JsonProperty("block_name")]
        public string BlockName { get; set; }

        [JsonProperty("pincode")]
        public string Pincode { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("long")]
        public string Longitude { get; set; }

        [JsonProperty("from")]
        public string FromDate { get; set; }

        [JsonProperty("to")]
        public string ToDate { get; set; }

        [JsonProperty("fee_type")]
        public string Fees { get; set; }

        [JsonProperty("sessions")]
        public Sessions[] AvailableSessions { get; set; }
    }
}
