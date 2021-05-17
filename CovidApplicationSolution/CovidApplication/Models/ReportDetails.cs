using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CovidApplication.Models
{
    public class ReportDetails
    {
        [DisplayName("RTPCR Score")]
        public int RTPCRTestScore { get; set; }

        [DisplayName("HRCT Score")]
        public int HRCTTestScore { get; set; }

        [DisplayName("CO-RADS Score")]
        public int CoRadsScore { get; set; }

        [DisplayName("CRP Score")]
        public int CRPScore { get; set; }

        [DisplayName("D-Dimer Score")]
        public float DDimerScore { get; set; }

        [DisplayName("1L6 Score")]
        public int OneL6Score { get; set; }

        [DisplayName("NLR Score")]
        public float NLRScore { get; set; }
    }
}