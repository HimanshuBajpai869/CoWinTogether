using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CovidApplication.Models
{
    public class CenterDetails
    {
        public string DistrictId { get; set; }

        public string CenterId { get; set; }

        public string CenterName { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [DisplayName("District")]
        public string DistrictName { get; set; }

        public string BlockName { get; set; }

        public string Pincode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string Fees { get; set; }
    }
}