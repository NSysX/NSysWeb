using Application.Parametros;

namespace Application.Features.Telefonos.Queries.ListarTelefonosQuery
{
    public class TelefonosParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string CodigoPais { get; set; }
        public string Numero { get; set; }
    }
}
