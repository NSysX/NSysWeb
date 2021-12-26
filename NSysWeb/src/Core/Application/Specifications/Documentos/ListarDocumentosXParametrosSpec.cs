using Ardalis.Specification;
using System;
using Domain.Entities;

namespace Application.Specifications.Documentos
{
    public class ListarDocumentosXParametrosSpec : Specification<Documento>
    {
        public ListarDocumentosXParametrosSpec(int numeroDePagina, int registrosXPagina, string estatus, string codigoUnico)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
                .Take(registrosXPagina)
                .Include(r => r.DocumentoTipo)
                .OrderBy(e => e.CodigoUnico);

            if (!String.IsNullOrEmpty(estatus))
                Query.Search(e => e.Estatus, "%" + estatus + "%");

            if (!String.IsNullOrEmpty(codigoUnico))
                Query.Search(c => c.CodigoUnico, "%" + codigoUnico + "%");
                    
        }
    }
}
