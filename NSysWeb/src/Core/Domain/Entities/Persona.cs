using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        public int IdPersona { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
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
