using CovidLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary
{
    public class OTPHelper
    {
        public async Task<GenerateOTPResponse> GenerateOTP(string mobileNumber)
        {
            string apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert
                    .SerializeObject(
                    new MobileNumberRequestProperties() { Mobile = mobileNumber }),
                    Encoding.UTF8,
                    "application/json");

                using (var response = await httpClient.PostAsync("https://cdn-api.co-vin.in/api/v2/auth/public/generateOTP", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<GenerateOTPResponse>(apiResponse);
                    }

                }
            }

            return new GenerateOTPResponse() { Message = apiResponse };
        }
    }
}
