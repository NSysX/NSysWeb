using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.EstadosCiviles
{
    public class ExisteEstadoCivilSpec : Specification<EstadoCivil>, ISingleResultSpecification
    {
        public ExisteEstadoCivilSpec(string descripcion, int id = 0)
        {
            if (!string.IsNullOrEmpty(descripcion))
                Query.Where(e => e.Descripcion == descripcion);

            if (id != 0)
            {
                Query.Where(e => e.IdEstadoCivil != id);
            }
        }
    }
}
