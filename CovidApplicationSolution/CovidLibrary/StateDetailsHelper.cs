using CovidLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary
{
    public class StateDetailsHelper
    {
        public async Task<StateDetails> GetAllStates()
        {
            var districts = await Helper.InvokeAPI($"https://cdn-api.co-vin.in/api/v2/admin/location/states").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<StateDetails>(districts);
        }

        public async Task<DistrictDetails> GetDistrictInState(string stateId)
        {
            var districts = await Helper.InvokeAPI($"https://cdn-api.co-vin.in/api/v2/admin/location/districts/{stateId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DistrictDetails>(districts);
        }
    }
}
