using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chamador.Application.Services
{
    public interface IExtracao
    {
        IRobo DefineRobo(IConfiguration configuration, ServiceProvider services, string roboId, int sleepTime, string path);
    }

}