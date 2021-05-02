using CovidApplication.Models;
using CovidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CovidApplication
{
    public class StateController : Controller
    {
        StateDetailsHelper stateDetailsHelper = new StateDetailsHelper();

        public async Task<ActionResult> GetAllStates()
        {
            var stateData = await stateDetailsHelper.GetAllStates().ConfigureAwait(false);
            List<StateDetails> stateDetails = new List<StateDetails>();
            stateData
                .States
                .ToList()
                .ForEach(
                state => stateDetails.Add(
                    new StateDetails()
                    {
                        StateId = state.StateId,
                        StateName = state.StateName
                    }
                ));

            return View(stateDetails);
        }

        public async Task<ActionResult> GetDistrictDetails(string stateId)
        {
            var districtData = await stateDetailsHelper.GetDistrictInState(stateId).ConfigureAwait(false);
            List<DistrictDetails> districtDetails = new List<DistrictDetails>();
            districtData
                .Districts
                .ToList()
                .ForEach(
                district => 
                districtDetails.Add(
                    new DistrictDetails()
                    {
                        DistrictID = district.DistrictID,
                        DistrictName = district.DistrictName
                    }
                ));

            return View(districtDetails);
        }

        public async Task<ActionResult> FillCity(string stateId)
        {
            var districtData = await stateDetailsHelper.GetDistrictInState(stateId).ConfigureAwait(false);
            List<DistrictDetails> districtDetails = new List<DistrictDetails>();
            districtData
                .Districts
                .ToList()
                .ForEach(
                district =>
                districtDetails.Add(
                    new DistrictDetails()
                    {
                        DistrictID = district.DistrictID,
                        DistrictName = district.DistrictName
                    }
                ));

            return Json(districtDetails, JsonRequestBehavior.AllowGet);
        }
    }
}