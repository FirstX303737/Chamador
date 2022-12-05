using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chamador.CLI.Configuration
{
    public class RoboConfig
    {
        public int Codigo{get;set;}
        public string Path {get;set;}

        public int SleepTime{get;set;}

        public RoboConfig(int codigo, string path, int sleepTime)
        {
            Codigo = codigo;
            Path = path;
            SleepTime = sleepTime;
        }
        public RoboConfig()
        {
            
        }
    }
}