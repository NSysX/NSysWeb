using Application.Parametros;

namespace Application.Features.EstadosCiviles.Queries.ListarEstadosCivilesQuery
{
    public class EstadosCivilesParametros : PaginacionDePeticion
    {
        // vamos a buscar x descripcion y habilitado y a la vez lo vamos a paginar
        // esta clase es para llenarla desde el controlador (Objeto)
        // y enviarla
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }
}
