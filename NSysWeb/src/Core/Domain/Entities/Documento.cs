using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Documento : EntidadBaseAuditable
    {
        public int IdDocumento { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Foto { get; set; }

        public virtual DocumentoTipo DocumentoTipo { get; set; }
        public List<PersonaDocumento> PersonaDocumentos { get; set; }
    }
}
