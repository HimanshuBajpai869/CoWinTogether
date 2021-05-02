using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary
{
    public static class Helper
    {
        public static async Task<string> InvokeAPI(string requestUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(requestUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            return string.Empty;
        }
    }
}
