using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.Personas
{
    public class ExistePersonaSpec : Specification<Persona> ,ISingleResultSpecification
    {
        public ExistePersonaSpec(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            Query
                .Where(p => p.ApellidoPaterno == apellidoPaterno && 
                            p.ApellidoMaterno == apellidoMaterno && 
                            p.Nombres == nombres);
        }
    }
}
