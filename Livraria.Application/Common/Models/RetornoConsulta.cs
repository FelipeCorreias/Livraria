using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Common.Models
{
    public class RetornoConsulta<T>
    {
        public int TotalRows { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
