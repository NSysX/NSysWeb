using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.AsentamientosTipos
{
    public class ListarAsentamientosTiposSpec : Specification<AsentamientoTipo>
    {
        public ListarAsentamientosTiposSpec(int numeroDePagina, int registrosXPagina, string estatus, string nombre, string abreviatura)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
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
