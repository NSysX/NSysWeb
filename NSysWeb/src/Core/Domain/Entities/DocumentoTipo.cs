using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class DocumentoTipo : EntidadBaseAuditable
    {
        public DocumentoTipo()
        {
            Documentos = new HashSet<Documento>();
        }

        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int LongitudMax { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
