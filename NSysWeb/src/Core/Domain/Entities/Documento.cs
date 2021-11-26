using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Documento : EntidadBaseAuditable
    {
        public Documento()
        {
            PersonaDocumentos = new HashSet<PersonaDocumento>();
        }

        public int IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; }
    }
}
