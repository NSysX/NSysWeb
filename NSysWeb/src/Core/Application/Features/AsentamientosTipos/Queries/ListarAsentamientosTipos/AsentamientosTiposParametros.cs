using Application.Parametros;

namespace Application.Features.AsentamientosTipos.Queries.ListarAsentamientosTipos
{
    public class AsentamientosTiposParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
