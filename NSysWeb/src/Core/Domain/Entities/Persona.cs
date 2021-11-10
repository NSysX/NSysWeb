using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Persona : EntidadBaseAuditable
    {
        public Persona()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        public int IdPersona { get; set; }
        public string Estatus { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public int IdNacionalidad { get; set; }
        public string Curp { get; set; }
        public string Nss { get; set; }
        public int? IdEstadoCivil { get; set; }

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Nacionalidad IdNacionalidadNavigation { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}
