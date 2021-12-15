using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CorreoElectronico : EntidadBaseAuditable
    {
        public int IdCorreoElectronico { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoEmail { get; set; }
    }
}
