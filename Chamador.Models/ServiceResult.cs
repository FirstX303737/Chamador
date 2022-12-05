using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chamador.Models
{
    public class ServiceResult<T> where T : ResponseModel
    {
        public Error Error { get; set; }
        public T Result { get; set; }
        public bool HasError { get { return Error != null; } }
    }
}