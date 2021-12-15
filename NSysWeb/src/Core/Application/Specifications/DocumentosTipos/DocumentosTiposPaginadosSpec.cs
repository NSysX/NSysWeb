using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications
{
    public class DocumentosTiposPaginadosSpec : Specification<DocumentoTipo>
    {
        public DocumentosTiposPaginadosSpec(int registrosXPagina, int numeroPagina, string nombre, string abreviatura, string estatus)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(x => x.Nombre);

            if (!String.IsNullOrEmpty(nombre))
                Query.Search(n => n.Nombre, "%" + nombre + "%")
                     .Where(r => r.EsHabilitado == true);

            if (!String.IsNullOrEmpty(abreviatura))
                Query.Where(a => a.Abreviatura == abreviatura);
        }
    }
}
