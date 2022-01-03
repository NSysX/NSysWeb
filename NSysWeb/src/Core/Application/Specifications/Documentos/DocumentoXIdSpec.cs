using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications.Documentos
{
    public class DocumentoXIdSpec : Specification<Documento>, ISingleResultSpecification
    {
        public DocumentoXIdSpec(int id)
        {
            if (id != 0)
                Query.Where(d => d.IdDocumento == id)
                    .Include(dt => dt.DocumentoTipo);
        }
    }
}
