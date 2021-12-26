using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CorreoElectronicoDTO
    {
        public int IdCorreoElectronico { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoCorreo { get; set; }
    }
}
