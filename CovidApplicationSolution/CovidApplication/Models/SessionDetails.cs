using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidApplication.Models
{
    public class SessionDetails
    {
        public string SessionId { get; set; }

        public string Date { get; set; }

        public string AvailabeSlots { get; set; }

        public string Slots { get; set; }

        public string Vaccine { get; set; }

        public string MinimumAgeLimit { get; set; }
    }
}