using System;
using System.Net.Http;
using System.Threading.Tasks;
using logitblog_bot.Models;
using Newtonsoft.Json;

namespace logitblog_bot.Services
{
    public class LuisService
    {
        public async Task<Luis> GetEntity(string query)
        {
            query = Uri.EscapeDataString(query);
            Luis data = new Luis();
            using (HttpClient client = new HttpClient())
            {
                string requestUri = $"https://api.projectoxford.ai/luis/v2.0/apps/60d66894-5ed1-488b-82db-4609b5680227?subscription-key=dd2b5fe1152844adbcc17a06dfacd3a5&q={query}&verbose=true";
                HttpResponseMessage returnMessage = await client.GetAsync(requestUri);

                if (returnMessage.IsSuccessStatusCode)
                {
                    var jsonDataResponse = await returnMessage.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<Luis>(jsonDataResponse);
                }
            }

            return data;
        }

    }
}