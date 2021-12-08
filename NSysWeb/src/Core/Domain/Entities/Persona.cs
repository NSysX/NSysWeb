using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public int IdNacionalidad { get; set; }
        public int IdEstadoCivil { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Notas { get; set; }

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Nacionalidad IdNacionalidadNavigation { get; set; }
    }
}
