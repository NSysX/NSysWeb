using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.AsentamientosTipos
{
    public class ListarAsentamientosTiposSpec : Specification<AsentamientoTipo>
    {
        public ListarAsentamientosTiposSpec(int registrosXPagina, int numeroPagina, string estatus, string nombre, string abreviatura)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(n => n.Nombre);

            if (!String.IsNullOrEmpty(estatus))
                Query.Search(e => e.Estatus, "%" + estatus + "%");

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%");

            if (!String.IsNullOrEmpty(abreviatura))
                Query.Search(a => a.Abreviatura, "%" + abreviatura + "%");
        }
    }
}
