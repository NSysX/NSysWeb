using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand
{
    // se hace publico y se implementa el patron mediador mediante herencia
    // el medidor funciona de la siguiente manera 
    // cuando se ejecuta una funcion hay un ente que me permite rederigir esa peticion
    public class InsertarEstadoCivilCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
    }

    // hay que impleentar el handler que tiene una peticion de entrada y una respuesta
    // LA ENTRADA SERIA LA CLASE DE ARRIBA 
    // Y VAMOS A RESPONDER CON LA CLASE ESTANGAR GENERICA RESPUESTA DE WRAper
    // Regresando un entero
    // aqui es donde se devuelve en eltero que es el id del registrod generado para su posterios consulta
    public class InsertarEstadoCivilCommand_Manejador : IRequestHandler<InsertarEstadoCivilCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<EstadoCivil> _respositorioAsync;
        // Luego llamamos a Mapper
        private readonly IMapper _mapper;
        // luego de la carpeta mappings vamos a crear una clase alli

        public InsertarEstadoCivilCommand_Manejador(IMapper mapper, IRepositorioAsync<EstadoCivil> repositorioAsync)
        {
            this._mapper = mapper;
            this._respositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(InsertarEstadoCivilCommand peticion, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<EstadoCivil>(peticion);
            var data = await _respositorioAsync.AddAsync(nuevoRegistro);

            return new Respuesta<int>(data.IdEstadoCivil);
        }
    }
}
