using System;
using System.Collections.Generic;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class TipoAsentamiento
    {
        public TipoAsentamiento()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdTipoAsentamiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}
