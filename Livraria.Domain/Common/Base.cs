using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Common
{
   public class Base
    {
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
    }
}
