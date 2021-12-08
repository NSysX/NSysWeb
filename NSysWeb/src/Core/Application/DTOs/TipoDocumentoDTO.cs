using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TipoDocumentoDTO
    {
        public int IdTipoDocumento { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public int Longitud { get; set; }
    }
}
