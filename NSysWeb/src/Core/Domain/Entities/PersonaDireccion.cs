﻿namespace Domain.Entities
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
