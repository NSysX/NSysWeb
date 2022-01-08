using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Paises
{
    public class PaisesXParametrosSpec : Specification<Pais>
    {
        public PaisesXParametrosSpec(int NumeroDePagina, int RegistrosXPagina, string nombre, string abreviatura)
        {
            Query.Skip((NumeroDePagina - 1) * NumeroDePagina)
                .Take(RegistrosXPagina)
                .OrderBy(n => n.Nombre);

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%");

            if(!String.IsNullOrEmpty(abreviatura))
                Query.Search(a => a.Abreviatura, "%" + abreviatura + "%");

        }
    }
}