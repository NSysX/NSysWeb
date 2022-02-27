using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.Personas
{
    public class PersonaXIdSpec : Specification<Persona>, ISingleResultSpecification
    {
        public PersonaXIdSpec(int id)
        {
            Query.Include(e => e.EstadoCivil)
                .Include(n => n.Nacionalidad)
                .Include(d => d.PersonaDocumentos)
                    .ThenInclude(d => d.Documento)
                    .ThenInclude(dt => dt.DocumentoTipo)
                .Include(t => t.PersonaTelefonos)
                    .ThenInclude(t => t.Telefono)
                .Include(pc => pc.PersonaCorreosElectronicos)
                    .ThenInclude(ce => ce.CorreoElectronico)
                .Include(pd => pd.PersonaDirecciones)
                    .ThenInclude(d => d.Direccion)
                    .ThenInclude(a => a.Asentamiento)
                        .ThenInclude(x => x.AsentamientoTipo)
                .Include(pd => pd.PersonaDirecciones)
                    .ThenInclude(d => d.Direccion)
                    .ThenInclude(a => a.Asentamiento)
                        .ThenInclude(x => x.Municipio)
                        .ThenInclude(e => e.Estado)
                        .ThenInclude(p => p.Pais)
                .AsSplitQuery()
                .Where(i => i.IdPersona == id)
                .OrderBy(ap => ap.ApellidoPaterno);
        }
    }
}
