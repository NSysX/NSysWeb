using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Personas
{
    public class ListarPersonasXParametrosSpec : Specification<Persona>
    {
        public ListarPersonasXParametrosSpec(int numeroDePagina, int registrosXPagina, string estatus, string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
                .Take(registrosXPagina)
                .Include(e => e.EstadoCivil)
                .Include(n => n.Nacionalidad)
                .Include(d => d.PersonaDocumentos)
                    .ThenInclude(d => d.Documento)
                    .ThenInclude(dt => dt.DocumentoTipo)
                .Include(t => t.PersonaTelefonos)
                    .ThenInclude(t => t.Telefono)
                .Include(pc => pc.PersonaCorreosElectronicos)
                    .ThenInclude(ce => ce.CorreoElectronico)
                .Include(pd => pd.PersonaDirecciones)
                .AsSplitQuery()
                .OrderBy(ap => ap.ApellidoPaterno);

            if (!String.IsNullOrEmpty(estatus))
                Query.Where(s => s.Estatus == estatus);

            if (!String.IsNullOrEmpty(apellidoPaterno))
                Query.Search(ap => ap.ApellidoPaterno, "%" + apellidoPaterno + "%");

            if (!String.IsNullOrEmpty(apellidoMaterno))
                Query.Search(am => am.ApellidoMaterno, "%" + apellidoMaterno + "%");

            if (!String.IsNullOrEmpty(nombres))
                Query.Search(n => n.Nombres, "%" + nombres + "%");
        }
    }
}
