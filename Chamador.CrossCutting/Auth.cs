using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chamador.CrossCutting
{
    public class Auth
    {
        public IConfiguration _configuration { get; }
        public Auth(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Auth()
        {
            
        }
        public async Task<string> GetToken()
        {

            var token = string.Empty;
            string uri = _configuration.GetSection("AuthUrl").Value;

            var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadAsStringAsync();
                return token;

            }
            return token;
        }
    }
}
