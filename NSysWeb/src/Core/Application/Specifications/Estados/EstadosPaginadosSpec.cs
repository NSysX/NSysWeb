using Ardalis.Specification;
using Domain.Entities;
using System;

namespace Application.Specifications.Estados
{
    public class EstadosPaginadosSpec : Specification<Estado>
    {
        public EstadosPaginadosSpec(int registrosXPagina, int numeroDePagina, string estatus, string nombre, string VariableAbrev)
        {
            Query.Skip((numeroDePagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(e => nombre);

            if (!String.IsNullOrEmpty(nombre))
            {
                Query.Search(n => n.Nombre, "%" + nombre + "%");
            }

            if (!String.IsNullOrEmpty(VariableAbrev))
            {
                Query.Search(a => a.VariableAbrev, "%" + VariableAbrev + "%");
            }

            if (!String.IsNullOrEmpty(estatus))
            {
                Query.Where(e => e.Estatus == estatus);
            }
            
        }
    }
}
