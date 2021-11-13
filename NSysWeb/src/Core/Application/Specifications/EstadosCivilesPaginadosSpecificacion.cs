using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class EstadosCivilesPaginadosSpecificacion : Specification<EstadoCivil>
    {
        public EstadosCivilesPaginadosSpecificacion(int registrosXPagina, int numeroPagina, string descripcion, string estatus)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(x => x.Descripcion);

            if (!String.IsNullOrEmpty(descripcion))
                Query.Search(x => x.Descripcion,"%" + descripcion + "%")
                    .Where(r => r.Es_Habilitado == true);

            if (!String.IsNullOrEmpty(estatus))
                Query.Where(x => x.Estatus == estatus && x.Es_Habilitado == true);
        }
    }
}
