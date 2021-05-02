using CovidApplication.Models;
using CovidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CovidApplication.Controllers
{
    public class VaccinationController : Controller
    {
        VaccinationDetailsHelper vaccinationDetailsHelper = new VaccinationDetailsHelper();

        StateDetailsHelper stateDetailsHelper = new StateDetailsHelper();

        public async Task<ActionResult> GetVaccinationCalenderForDistrict(string districtID)
        {
            var centerData = await vaccinationDetailsHelper.GetVaccinationDetailsInDistrict(districtID).ConfigureAwait(false);
            List<CenterDetails> centerDetails = new List<CenterDetails>();

            if (centerData != null)
            {
                centerData
                    .Centers
                    .ToList()
                    .ForEach(
                    center =>
                    {
                        if(ViewBag.State == null)
                        {
                            ViewBag.State = center.StateName;
                            ViewBag.DistrictName = center.DistrictName;
                        }
                        centerDetails.Add(
                            new CenterDetails()
                            {
                                DistrictId = districtID,
                                CenterId = center.CenterId,
                                CenterName = center.CenterName,
                                BlockName = center.BlockName,
                                DistrictName = center.DistrictName,
                                Fees = center.Fees,
                                FromDate = center.FromDate,
                                Latitude = center.Latitude,
                                Longitude = center.Longitude,
                                Pincode = center.Pincode,
                                StateName = center.StateName,
                                ToDate = center.ToDate
                            });
                    });
            }


            return View(centerDetails);
        }

        public async Task<ActionResult> GetAvailableSessionsInCenter(string districtID, string centerID)
        {
            var centerData = await vaccinationDetailsHelper.GetVaccinationDetailsInDistrict(districtID).ConfigureAwait(false);
            var sessions = centerData
                .Centers
                .Where(
                center => center.CenterId.Equals(centerID))
                .Select(x => x.AvailableSessions).ToList();
            List<SessionDetails> sessionDetails = new List<SessionDetails>();
            foreach (var session in sessions)
            {
                session
                    .ToList()
                    .ForEach(
                    x =>
                    {
                        sessionDetails.Add(
                            new SessionDetails()
                            {
                                AvailabeSlots = x.AvailabeSlots,
                                MinimumAgeLimit = x.MinimumAgeLimit,
                                Date = x.Date,
                                Slots = string.Join(" , ", x.Slots),
                                Vaccine = string.IsNullOrEmpty(x.Vaccine) ? "NA" : x.Vaccine
                            });
                    });

            }

            return View(sessionDetails);
        }

        public async Task<ActionResult> VaccinationForYoung()
        {
            List<SelectListItem> statesName = new List<SelectListItem>();
            var statesData = await stateDetailsHelper.GetAllStates().ConfigureAwait(false);
            foreach (var state in statesData.States)
            {
                statesName.Add(new SelectListItem() { Text = state.StateName, Value = state.StateId });
            }

            ViewBag.States = new SelectList(statesName, "Value", "Text"); ;
            return View();
        }

        public async Task<ActionResult> FillPincode(string districtId)
        {
            var centerData = await this.vaccinationDetailsHelper.GetVaccinationDetailsInDistrict(districtId).ConfigureAwait(false);
            List<string> pincodes = new List<string>();
            centerData
                .Centers
                .Where(
                x => x.AvailableSessions.ToList().Where(y=> Convert.ToInt32(y.MinimumAgeLimit) >= 18 && Convert.ToInt32(y.MinimumAgeLimit) < 45).Any())
                .ToList()
                .ForEach(
                center =>
                {
                    pincodes.Add(center.Pincode);
                });
            return Json(pincodes, JsonRequestBehavior.AllowGet);
        }

        
        public async Task<ActionResult> CenterDetailsBasedOnPinCode(string districtId = "664", string pincode = "208027")
        {
            var centerData = await this.vaccinationDetailsHelper.GetVaccinationDetailsInDistrict(districtId).ConfigureAwait(false);
            var centersForYoung = centerData
                .Centers
                .Where(
                x => x.Pincode == pincode && x.AvailableSessions.ToList().Where(y => Convert.ToInt32(y.MinimumAgeLimit) >= 18 && Convert.ToInt32(y.MinimumAgeLimit) < 45).Any()).ToList();

            List<CenterDetails> centerDetails = new List<CenterDetails>();

            if (centerData != null)
            {
                centersForYoung
                    .ToList()
                    .ForEach(
                    center =>
                    {
                        if (ViewBag.State == null)
                        {
                            ViewBag.State = center.StateName;
                            ViewBag.DistrictName = center.DistrictName;
                        }
                        centerDetails.Add(
                            new CenterDetails()
                            {
                                DistrictId = districtId,
                                CenterId = center.CenterId,
                                CenterName = center.CenterName,
                                BlockName = center.BlockName,
                                DistrictName = center.DistrictName,
                                Fees = center.Fees,
                                FromDate = center.FromDate,
                                Latitude = center.Latitude,
                                Longitude = center.Longitude,
                                Pincode = center.Pincode,
                                StateName = center.StateName,
                                ToDate = center.ToDate
                            });
                    });
            }
            return PartialView("_CenterDetailsBasedOnPinCode", centerDetails);
        }

        public ActionResult VaccineAvailability()
        {
            List<SelectListItem> vaccineList = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "COVISHIELD", Value = "COVISHIELD" }
            };

            ViewBag.Vaccines = new SelectList(vaccineList, "Value", "Text"); ;
            return View();
        }
    }
}