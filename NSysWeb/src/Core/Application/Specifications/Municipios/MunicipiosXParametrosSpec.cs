using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Municipios
{
    public class MunicipiosXParametrosSpec : Specification<Municipio>
    {
        public MunicipiosXParametrosSpec(int numeroDePagina, int registrosXPagina, string nombre, int clave)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
                .Take(registrosXPagina)
                .Include(e => e.Estado)
                .OrderBy(n => n.Nombre);

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%");

            if (clave != 0)
                Query.Where(c => c.Clave == clave);
        }
    }
}
