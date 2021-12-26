using Application.Parametros;

namespace Application.Features.CorreosElectronicos.Queries.ListarCorreosElectronicos
{
    public class CorreosElectronicosParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string Correo { get; set; }
    }
}
