using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public int Codigo { get; set; }
        public string Nacionalidad1 { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
