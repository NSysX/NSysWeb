using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications
{
    public class TiposDocumentosPaginadosSpec : Specification<DocumentoTipo>
    {
        public TiposDocumentosPaginadosSpec(int registrosXPagina, int numeroPagina, string nombre, string abreviacion, string estatus)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(x => x.Nombre);

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%")
                     .Where(r => r.EsHabilitado == true);

            if (!String.IsNullOrEmpty(abreviacion))
                Query.Where(a => a.Abreviacion == abreviacion);
        }
    }
}
