using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public bool Es_Habilitado { get; set; }
        public string Estatus { get; set; }
    }
}
