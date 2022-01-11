using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.Direcciones
{
    public class DireccionesXParametrosSpec : Specification<Direccion>
    {
        public DireccionesXParametrosSpec(int numeroDePaginas, int registroXPagina, string calle)
        {
            Query.Skip((numeroDePaginas - 1) * numeroDePaginas)
                .Take(registroXPagina)
                .Include(a => a.Asentamiento)
                     .ThenInclude(at => at.AsentamientoTipo)
                .OrderBy(c => c.Calle);

            if (!String.IsNullOrEmpty(calle))
                Query.Search(c => c.Calle, "%" + calle + "%");
        }
    }
}
