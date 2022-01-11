using System.Collections.Generic;

namespace Application.DTOs
{
    public class AsentamientoDTO
    {
        public int IdAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
        public int IdAsentamientoTipo { get; set; }

        public virtual AsentamientoTipoDTO AsentamientoTipo { get; set; }
        public int IdMunicipio { get; set; }
        public virtual MunicipioDTO Municipio { get; set; }
        //public virtual ICollection<DireccionDTO> Direcciones { get; set; }
    }
}
