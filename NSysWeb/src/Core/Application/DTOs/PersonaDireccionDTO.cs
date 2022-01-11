namespace Application.DTOs
{
    public class PersonaDireccionDTO
    {
        public int IdPersonaDireccion { get; set; }
        public int IdPersona { get; set; }
        public int IdDireccion { get; set; }

        public DireccionDTO Direccion { get; set; }
    }
}
