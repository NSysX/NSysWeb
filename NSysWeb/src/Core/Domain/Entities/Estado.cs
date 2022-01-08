using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Estado : EntidadBaseAuditable
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int IdEstado { get; set; }
        public int IdPais { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string VariableAbrev { get; set; }
        public string RenapoAbrev { get; set; }
        public string TresDigitosAbrev { get; set; }
        public int Clave { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
