namespace Application.DTOs
{
    public class PersonaCorreoElectronicoDTO 
    {
        public int IdPersonaCorreoElectronico { get; set; }
        public int IdPersona { get; set; }
        public int IdCorreoElectronico { get; set; }

        public CorreoElectronicoDTO CorreoElectronico { get; set; }
    }
}