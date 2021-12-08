using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications
{
    public class EstadosCivilesPaginadosSpec : Specification<EstadoCivil>
    {
        public EstadosCivilesPaginadosSpec(int registrosXPagina, int numeroPagina, string descripcion, string estatus)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(x => x.Descripcion);

            if (!String.IsNullOrEmpty(descripcion))
                Query.Search(x => x.Descripcion,"%" + descripcion + "%")
                    .Where(r => r.EsHabilitado == true);

            if (!String.IsNullOrEmpty(estatus))
                Query.Where(x => x.Estatus == estatus && x.EsHabilitado == true);
        }
    }
}
