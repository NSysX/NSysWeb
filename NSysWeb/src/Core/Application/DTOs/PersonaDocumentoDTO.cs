using System.Collections.Generic;

namespace Application.DTOs
{
    public class PersonaDocumentoDTO 
    {
        public int IdPersonaDocumento { get; set; }
        public int IdPersona { get; set; }
        public int IdDocumento { get; set; }

        public DocumentoDTO Documento { get; set; }
    }
}
