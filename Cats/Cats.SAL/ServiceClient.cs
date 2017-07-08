using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Cats.Entities;
using Newtonsoft.Json;

namespace Cats.SAL
{
    public class ServiceClient
    {
        public async Task<List<Cat>> GetCatsAsync()
        {
            List<Cat> Cats = null;

            // Dirección del servicio REST
            string URI ="https://ticapacitacion.com/cats";

            using (var Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Realizamos una petición GET
                    var Response =await Client.GetAsync(URI);

                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                      Cats = JsonConvert.DeserializeObject<List<Cat>>(ResultWebAPI);
                    }
                }
                catch (System.Exception ex)
                {
                    var error = ex.Message;
                }
            }
            return Cats;
        }
    }
}
