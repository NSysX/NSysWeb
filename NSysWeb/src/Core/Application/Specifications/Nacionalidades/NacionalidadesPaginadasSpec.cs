using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Nacionalidades
{
    public class NacionalidadesPaginadasSpec : Specification<Nacionalidad>
    {
        public NacionalidadesPaginadasSpec(int registrosXPagina, int numeroDePagina, string descripcion, string estatus)
        {
            Query.Skip((numeroDePagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(e => e.Descripcion);

            if (!String.IsNullOrEmpty(descripcion))
                Query.Search(e => e.Descripcion, "%" + descripcion + "%")
                    .Where(r => r.EsHabilitado == true);

            if (!String.IsNullOrEmpty(estatus))
                Query.Where(x => x.Estatus == estatus && x.EsHabilitado == true);
        }
    }
}
