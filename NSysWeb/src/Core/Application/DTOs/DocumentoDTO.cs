using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DocumentoDTO
    {
        public int IdDocumento { get; set; }
        public TipoDocumentoDTO MyProperty { get; set; }
    }
}
