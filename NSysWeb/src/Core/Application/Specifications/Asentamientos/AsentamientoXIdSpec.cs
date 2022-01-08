using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications.Asentamientos
{
    public class AsentamientoXIdSpec : Specification<Asentamiento>, ISingleResultSpecification
    {
        public AsentamientoXIdSpec(int id)
        {
            Query.Where(a => a.IdAsentamiento == id)
                .Include(at => at.AsentamientoTipo)
                .Include(m => m.Municipio)
                     .ThenInclude(e => e.Estado)
                .Include(d => d.Direcciones);      
        }
    }
}
