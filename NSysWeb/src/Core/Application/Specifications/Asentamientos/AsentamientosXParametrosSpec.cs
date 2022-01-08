using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Asentamientos
{
    public class AsentamientosXParametrosSpec : Specification<Asentamiento>
    {
        public AsentamientosXParametrosSpec(int numeroDePagina, int registrosXPagina, string nombre, int codigoPostal)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
                .Take(registrosXPagina)
                .Include(at => at.AsentamientoTipo)
                .Include(m => m.Municipio)
                  .ThenInclude(e => e.Estado)
                  .ThenInclude(p => p.Pais)
                .AsSplitQuery()
                .OrderBy(x => x.Nombre);

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%");

            if (codigoPostal != 0)
                Query.Where(c => c.CodigoPostal == codigoPostal);
        }
    }
}
