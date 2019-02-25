using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Application.Common.Models
{
    public class Filtro
    {
        public int? Start { get; set; }
        public int? Length { get; set; }
        public string SortField { get; set; }
        public string SortType { get; set; }
    }
}
