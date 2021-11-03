using System;
using System.Collections.Generic;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
