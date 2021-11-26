using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class TipoDocumento : EntidadBaseAuditable
    {
        public int IdTipoDocumento { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Longitud { get; set; }
    }
}
