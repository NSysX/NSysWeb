using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Municipio
    {
        public Municipio()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}
