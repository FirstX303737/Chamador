using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chamador.Application.Services.Robos;
namespace Chamador.Application.Services
{
    public class Extracao : IExtracao
    {
        public IRobo DefineRobo(IConfiguration configuration, ServiceProvider services, string roboId, int sleepTime, string path)
        {
            switch (roboId)
            {
                case "21":
                    return new Robo01(sleepTime, path);
                case "2":
                    return new Robo02(sleepTime, path);
                default:
                    throw new ArgumentException("O robo não definido.");
            }
            throw new System.NotImplementedException();
        }
    }
}