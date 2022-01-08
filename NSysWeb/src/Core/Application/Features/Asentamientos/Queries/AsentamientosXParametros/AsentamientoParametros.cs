using Application.Parametros;

namespace Application.Features.Asentamientos.Queries.AsentamientosXParametros
{
    public class AsentamientoParametros : PaginacionDePeticion
    {
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
    }
}
