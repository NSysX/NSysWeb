using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EstadoCivil.Commands.CreateEstadoCivilCommand
{
    // se usa el patron mediatr y cuando llamen a este comando necesito crear el mediador
    // mediatr funciona cuando se ejecuta una funcion hay un ente en medio que me permite redirigir esa peticion
    // a la implementacion de ese objeto 
    // por ejemplo cuando desde la api llamen este atravez de IRequest hay un manejador que hace este codigo
    public class CreateEstadoCivilCommand : IRequest<Respuesta<int>>
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
    
    // automaticamente se va a ejecutar esta clase manejador
    public class CreateEstadoCivilHandler : IRequestHandler<CreateEstadoCivilCommand, Respuesta<int>>
    {
        public async Task<Respuesta<int>> Handle(CreateEstadoCivilCommand peticion, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
: 
}
