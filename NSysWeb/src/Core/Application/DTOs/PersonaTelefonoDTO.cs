using System.Collections.Generic;

namespace Application.DTOs
{
    public class PersonaTelefonoDTO
    {
        public int IdPersonaTelefono { get; set; }
        public int IdPersona { get; set; }
        public int IdTelefono { get; set; }

        public TelefonoDTO Telefono { get; set; }
    }
}
