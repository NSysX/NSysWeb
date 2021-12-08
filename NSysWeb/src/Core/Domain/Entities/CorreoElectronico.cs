using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CorreoElectronico
    {
        public int IdCorreoElectronico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoEmail { get; set; }
    }
}
