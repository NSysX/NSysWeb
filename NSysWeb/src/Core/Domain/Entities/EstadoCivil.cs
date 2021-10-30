using Domain.Common;

namespace Domain.Entities
{
    public class EstadoCivil : AuditableBaseEntity
    {
        //public override int Id { get => base.Id; set => base.Id = value; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
