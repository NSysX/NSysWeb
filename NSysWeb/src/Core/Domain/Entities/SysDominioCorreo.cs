using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class SysDominioCorreo : EntidadBaseAuditable
    {
        public int IdSysDominioCorreo { get; set; }
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }
}
