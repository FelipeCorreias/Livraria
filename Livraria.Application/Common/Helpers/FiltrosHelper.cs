using Livraria.Application.Common.Linq;
using Livraria.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Application.Common.Helpers
{
    public static class FiltrosHelper
    {
        public static IQueryable<T> OrdenacaoPaginacao<T>(IQueryable<T> consulta, Filtro filtro)
        {

            if (!string.IsNullOrEmpty(filtro.SortField) && !string.IsNullOrEmpty(filtro.SortType))
                consulta = consulta.OrderByField(filtro.SortField, (filtro.SortType.ToUpper().Trim() == "DESC" ? false : true));

            if (filtro.Start.HasValue && filtro.Length.HasValue && filtro.Length.Value > 0)
                consulta = consulta.Skip(filtro.Start.Value).Take(filtro.Length.Value);

            return consulta;
        }

    }
}
