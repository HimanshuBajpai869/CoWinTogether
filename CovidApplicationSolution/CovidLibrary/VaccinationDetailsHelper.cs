using CovidLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary
{
    public class VaccinationDetailsHelper
    {
        public async Task<CenterDetails> GetVaccinationDetailsInDistrict(string districtId)
        {
            var centerDetails = await Helper.InvokeAPI($"https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByDistrict?district_id={districtId}&date={DateTime.Now.ToString("dd-MM-yyyy")}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CenterDetails>(centerDetails);
        }
    }
}
