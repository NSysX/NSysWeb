using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Municipio
    {
        public Municipio()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdMunicipio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public int IdEstado { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}
