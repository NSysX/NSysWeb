using Domain.Common;
using System;

#nullable disable

namespace Domain.Entities
{
    public partial class Documento : EntidadBaseAuditable
    {
        public int IdDocumento { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Imagen { get; set; }

        public virtual DocumentoTipo IdDocumentoTipoNavigation { get; set; }
    }
}
