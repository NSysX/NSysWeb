using System;
using System.Collections.Generic;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdEstadoCivil { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
