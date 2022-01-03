using Application.Parametros;

namespace Application.Features.Estados.Queries.ListarEstados
{
    public class EstadosParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string VariableAbrev { get; set; }
    }
}
