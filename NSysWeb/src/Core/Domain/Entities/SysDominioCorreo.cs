using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class SysDominioCorreo : EntidadBaseAuditable
    {
        public int IdSysDominioCorreo { get; set; }
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }
}
