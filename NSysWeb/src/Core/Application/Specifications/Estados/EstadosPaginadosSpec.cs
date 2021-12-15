using Ardalis.Specification;
using Domain.Entities;
using System;

namespace Application.Specifications.Estados
{
    public class EstadosPaginadosSpec : Specification<Estado>
    {
        public EstadosPaginadosSpec(int registrosXPagina, int numeroDePagina, string estatus, string nombre, string abreviatura)
        {
            Query.Skip((numeroDePagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(e => nombre);

            if (!String.IsNullOrEmpty(nombre))
            {
                Query.Search(n => n.Nombre, "%" + nombre + "%");
            }

            if (!String.IsNullOrEmpty(abreviatura))
            {
                Query.Search(a => a.Abreviatura, "%" + abreviatura + "%");
            }

            if (!String.IsNullOrEmpty(estatus))
            {
                Query.Where(e => e.Estatus == estatus);
            }
            
        }
    }
}
