using MVCITE.Repository.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVCITE.Repository.Managers
{
    public class LoginManager
    {
        static string _baseAddress;
        static HttpClient client;

        public LoginManager(string baseAddress)
        {
            try
            {
                _baseAddress = baseAddress;
                client = new HttpClient
                {
                    BaseAddress = new Uri(_baseAddress)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch
            {

            }
        }

        public async Task<bool> IsAliveMVCITEService(string endPointAddress)
        {
            bool res = false;
            HttpResponseMessage Res = await client.GetAsync(endPointAddress);

            if (Res.IsSuccessStatusCode)
            {
                var response = Res.Content.ReadAsStringAsync().Result;
                res = JsonConvert.DeserializeObject<bool>(response);
            }
            return res;
        }

        public async Task<LoginResponseDTO> IsSecurityUser(string endPointAddress, LoginRequestDTO loginRequestDTO)
        {
            //string myName = System.Reflection.MethodBase.GetCurrentMethod.Name;
            LoginResponseDTO res = new LoginResponseDTO();

            var response = await client.PostAsJsonAsync(endPointAddress, loginRequestDTO);

            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsStringAsync().Result;               
                res = JsonConvert.DeserializeObject<LoginResponseDTO>(r);
            }
            else
            {
                res = null;
            }

            return res;
        }
    }
}
