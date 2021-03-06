using System;
using System.Collections.Generic;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class Asentamiento
    {
        public Asentamiento()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdAsentamiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public int Codigo { get; set; }
        public int IdTipoAsentamiento { get; set; }
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual TipoAsentamiento IdTipoAsentamientoNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
