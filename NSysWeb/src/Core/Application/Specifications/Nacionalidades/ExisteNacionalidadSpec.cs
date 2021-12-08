using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Nacionalidades
{
    public class ExisteNacionalidadSpec : Specification<Nacionalidad> , ISingleResultSpecification
    {
        public ExisteNacionalidadSpec(string descripcion,int id)
        {
            Query
                .Where(d => d.Descripcion == descripcion && d.IdNacionalidad != id);
        }
    }
}
