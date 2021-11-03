using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
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
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
