using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CovidApplication.Models
{
    public class StateDetails
    {
        public string StateId { get; set; }

        [DisplayName("State Name")]
        public string StateName { get; set; }
    }
}