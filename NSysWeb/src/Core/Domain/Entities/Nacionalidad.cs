using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdNacionalidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
