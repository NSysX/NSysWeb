using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications.Municipios
{
    public class MunicipioXIdSpec : Specification<Municipio>, ISingleResultSpecification
    {
        public MunicipioXIdSpec(int id)
        {
            Query.Where(i => i.IdMunicipio == id)
                .Include(e => e.Estado);
        }
    }
}
