using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chamador.Models
{
    public class Error
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}