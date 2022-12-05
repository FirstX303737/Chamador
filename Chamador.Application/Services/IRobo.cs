using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chamador.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chamador.Application.Services
{
    public interface IRobo
    {
        DateTime UltimaVezRodou { get; set; }
        int SleepTime{ get; }

        Task<ResponseModel> Extrair(IConfiguration configuration, ServiceProvider services);

        Task Consulta(IConfiguration configuration, ServiceProvider services);

        Task GerenciaDadoExtraidoRobo();
    }
}