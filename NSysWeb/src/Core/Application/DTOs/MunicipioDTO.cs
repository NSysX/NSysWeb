namespace Application.DTOs
{
    public class MunicipioDTO
    {
        public int IdMunicipio { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int Clave { get; set; }
        public string Ciudad { get; set; }
        public int IdEstado { get; set; }

        public virtual EstadoDTO Estado { get; set; }
    }
}
