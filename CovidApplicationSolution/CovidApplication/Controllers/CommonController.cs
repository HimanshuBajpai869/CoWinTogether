using CovidApplication.Models;
using CovidLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CovidApplication.Controllers
{
    public class CommonController : Controller
    {
        OTPHelper otpHelper = new OTPHelper();

        ReportEvaluationHelper reportEvaluationHelper = new ReportEvaluationHelper();

        public ActionResult AnalyzeCovidReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EvaluateTestScore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EvaluateTestScore(ReportDetails reportDetails)
        {
            ViewBag.EvaluationResult = reportEvaluationHelper.EvaluateTestScore(
                reportDetails.RTPCRTestScore,
                reportDetails.HRCTTestScore,
                reportDetails.CoRadsScore,
                reportDetails.CRPScore,
                reportDetails.DDimerScore,
                reportDetails.OneL6Score,
                reportDetails.NLRScore);

            return View(reportDetails);
        }

        [HttpGet]
        public ActionResult GenerateOTP()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GenerateOTP(MobileNumberDetails mobileNumberDetails)
        {
            var generateOTPResponse = await otpHelper.GenerateOTP(mobileNumberDetails.MobileNumber).ConfigureAwait(false);
            if (string.IsNullOrEmpty(generateOTPResponse.Message))
            {
                ViewBag.GenerateOTPResponse = $"OTP sent successfully and it will be valid for 3 minutes. Transaction ID - {generateOTPResponse.TransactionId}";
            }
            else
            {
                ViewBag.GenerateOTPResponse = generateOTPResponse.Message;
            }

            return View(mobileNumberDetails);
        }
    }
}