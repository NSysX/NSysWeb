using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class DocumentoTipo
    {
        public int IdTipoDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public int Longitud { get; set; }
    }
}
