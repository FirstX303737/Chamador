using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chamador.Models;
using Chamador.Infra;
using System.Net.Http;
using Newtonsoft.Json;

namespace Chamador.Application.Services.Robos
{
    public class Robo01 : IRobo
    {
        private readonly string path;
     
        public int SleepTime{ get; private set; }
     
        public DateTime UltimaVezRodou { get; set; }

        public Robo01(int sleepTime, string path)
        {
            this.SleepTime = sleepTime;
            this.path = path;
        }

        public async Task<ResponseModel> Extrair(IConfiguration configuration, ServiceProvider services)
        {
            var eventService = services.GetService<IInfra<ServiceResult<ResponseModel>>>();
            
            var corpo = new Robo01RequestModel
            {
                Id = 1,
                Name = "Nilo",
                Properties = "Funcional"
            };
            var resultado = Task.Run<ServiceResult<ResponseModel>> (async () => {
               return await eventService.Exchange(HttpMethod.Post, new Uri("http://demo0928808.mockable.io"),"/robo01",string.Empty, new Robo01ResponseModel(), corpo);
            });

            await Task.WhenAll(new Task[1]{resultado});
           
            
            var robo01 = (Robo01ResponseModel)resultado.Result.Result;            
            System.Console.WriteLine($"Nome ------>>>> {robo01.Name}");
            System.Console.WriteLine($"Id   ------>>>> {robo01.Id}");
            System.Console.WriteLine($"Properties ------>>>> {robo01.Properties}");
            System.Console.WriteLine($"Ultima Vez Que Rodou ------>>>> {this.UltimaVezRodou.ToString()}");
            Console.WriteLine($"Esse é o resultado: { JsonConvert.SerializeObject(resultado.Result.Result, typeof(Robo01ResponseModel), null)}");
            
            return resultado.Result.Result;
        }

        public async Task Consulta(IConfiguration configuration, ServiceProvider services)
        {            
            await Task.Run(() =>{});
        }

        public async Task GerenciaDadoExtraidoRobo()
        {
            await Task.Run(() =>{});
        }
    }
}