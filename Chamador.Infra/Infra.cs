#define local
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using Chamador.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Chamador.Infra
{
    public class Infra<T> : IInfra<T> where T : ServiceResult<ResponseModel>
    {
        public async Task<T> Exchange(HttpMethod metodoHttp, Uri baseUrl, string rota, string token, ResponseModel responseModel, RequestModel body = null)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

#if local
            var HttpClient = new HttpClient(clientHandler);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
#else
            var HttpClient = new HttpClient();
#endif
            var serviceResult = new ServiceResult<ResponseModel>();
            var resposta = new HttpResponseMessage();
            try 
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);

                switch (metodoHttp.Method)
                {
                case "GET":                
                    resposta = await HttpClient.GetAsync($"{baseUrl.ToString()}{rota}");
                    serviceResult = await DeserializaResposta(resposta, baseUrl, rota, responseModel);
                    break;

                case "POST":
                    resposta = await HttpClient.PostAsync($"{baseUrl.ToString()}{rota}", new StringContent(JsonConvert.SerializeObject(body), UTF8Encoding.UTF8, "application/json"));                    
                    serviceResult = await DeserializaResposta(resposta, baseUrl, rota, responseModel, body);
                    break;
                    
                default:
                    //TODO
                    throw new NotImplementedException();
                    throw new Exception("");
                }
                return (T)serviceResult;
            }
            catch (Exception ex)
            {
                // CW
                 var error = new Error();
                 error.Exception = ex.InnerException.ToString();
                 error.Message = ex.Message;;
                 error.Request = JsonConvert.SerializeObject(body);
                 //error.Response = JsonConvert.DeserializeObject<ResponseModel>(data);
                 serviceResult.Error = error;                 
                 return (T)serviceResult;
            }
        }

        private async Task<ServiceResult<ResponseModel>> DeserializaResposta(HttpResponseMessage resposta, Uri baseUrl, string rota, ResponseModel responseModel, RequestModel body = null)
        {
            var serviceResult = new ServiceResult<ResponseModel>();
            try{
                if (resposta.StatusCode == HttpStatusCode.OK)
                {                
                    serviceResult.Result = JsonConvert.DeserializeObject(await resposta.Content.ReadAsStringAsync(), responseModel.GetType()) as ResponseModel;
                }
                else
                {
                    if(body == null)
                    {
                        serviceResult.Error = new Error{ Message = $"Erro ao receber resposta do servidor - UrlBase: {baseUrl} Rota: {rota} Status: {resposta.StatusCode}" };
                    }
                    else
                    {
                        serviceResult.Error = new Error{ Message = $"Erro ao receber resposta do servidor - UrlBase: {baseUrl} Rota: {rota} Corpo: {body} Status: {resposta.StatusCode}" };
                    }                
                }
            }
            catch(Exception ex)
            {                
                var error = new Error();
                error.Exception = ex.InnerException.ToString(); 
                error.Message = $"Erro durante a deserializacao da resposta da requisicao Url base {baseUrl} para a rota {rota}  ex.Message: {ex.Message} ";
                serviceResult.Error = error;
            }
            return serviceResult;
        }
    }
}
