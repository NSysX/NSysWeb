using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Las direcciones que tiene una persona
    /// </summary>
    public partial class PersonaDireccion
    {
        public int IdPersonaDireccion { get; set; }
        /// <summary>
        /// El id de la tabla de Personas
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// El id de la Tabla Direccion
        /// </summary>
        public int IdDireccion { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
    }
}
