using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class Municipio : EntidadBaseAuditable
    {
        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int Clave { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
