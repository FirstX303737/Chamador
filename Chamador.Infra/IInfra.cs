using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Chamador.Models;

namespace Chamador.Infra
{
    public interface IInfra<T> where T : ServiceResult<ResponseModel>
    {
       Task<T> Exchange(HttpMethod metodoHttp, Uri baseUrl, string rota, string token, ResponseModel responseModel, RequestModel body = null);
    }
}