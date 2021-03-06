using System;
using System.Collections.Generic;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class PersonaDireccion
    {
        public int IdPersonaDireccion { get; set; }
        public int IdPersona { get; set; }
        public int IdDireccion { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
