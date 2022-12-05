using System;
using System.Threading.Tasks;
using Chamador.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chamador.Application.Services
{
    public class Robo02 : IRobo
    {
        private readonly string path;
        private readonly int sleepTime;

        public Robo02(int sleepTime, string path)
        {
            this.sleepTime = sleepTime;
            this.path = path;
            
        }
        public DateTime UltimaVezRodou { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int SleepTime => throw new NotImplementedException();

        public Task Consulta(IConfiguration configuration, ServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Extrair(IConfiguration configuration, ServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public Task GerenciaDadoExtraidoRobo()
        {
            throw new NotImplementedException();
        }
    }
}