using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications.Estados
{
    public class EstadoXIdSpec : Specification<Estado>, ISingleResultSpecification
    {
        public EstadoXIdSpec(int id)
        {
            Query.Where(i => i.IdEstado == id)
                .Include(p => p.Pais);
        }
    }
}
