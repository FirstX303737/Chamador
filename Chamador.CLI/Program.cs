using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Chamador.Infra;
using Chamador.CrossCutting;
using Chamador.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Chamador.CLI.Configuration;
using Chamador.Application.Services;

namespace Chamador.CLI
{
    class Program
    {
        public async static Task Main(string[] args)
        {
           
            var serviceProvider = ObtemServices();            
            
            var config = ObtemConfigurations();            

            var robos = ObtemRobos(config);

            List<IRobo> instanciasRobos = new List<IRobo>();

            Parallel.ForEach(robos, (robo) => 
            {
                Console.WriteLine($"Robo#: {robo.Codigo} Path: {robo.Path} SleepTime: {robo.SleepTime}");
                instanciasRobos.Add(new Extracao().DefineRobo(config, serviceProvider, robo.Codigo.ToString(), robo.SleepTime, robo.Path));
            });

            while (true)
            {
                Parallel.ForEach(instanciasRobos, async (robo) => 
                {
                    
                    if(DateTime.Compare(robo.UltimaVezRodou.AddMilliseconds(robo.SleepTime), DateTime.Now) > 0)
                    {
                        System.Console.WriteLine($"{robo.UltimaVezRodou.ToString("yyyy-MM-dd")}");
                    }
                    await robo.Extrair(config, serviceProvider);
                    robo.UltimaVezRodou = DateTime.Now;
                });
            }
        }

        public static void ConfigureServices(IServiceCollection services) =>        
            services   
            .AddScoped(typeof(IInfra<ServiceResult<ResponseModel>>), typeof(Infra<ServiceResult<ResponseModel>>))            
            .AddScoped<AD>()
            .AddScoped<Auth>();
 
        private static ServiceProvider ObtemServices()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration ObtemConfigurations() =>        
             new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)            
            .AddJsonFile("appsettings.json",false)
            .Build();

        private static IEnumerable<RoboConfig> ObtemRobos(IConfiguration config) =>        
             config.GetSection("Robos").Get<List<RoboConfig>>();
    }
}
