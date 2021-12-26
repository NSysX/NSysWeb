using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Telefono : EntidadBaseAuditable
    {
        public int IdTelefono { get; set; }
        public string Estatus { get; set; }
        public string TipoTelefono { get; set; }
        public string CodigoPais { get; set; }
        public string Numero { get; set; }

        public List<PersonaTelefono>  PersonaTelefonos { get; set; }
    }
}
