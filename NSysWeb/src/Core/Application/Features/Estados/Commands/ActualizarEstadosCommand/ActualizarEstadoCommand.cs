using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Estados.Commands.ActualizarEstadosCommand
{
    public class ActualizarEstadoCommand : IRequest<Respuesta<int>>
    {
        public int IdEstado { get; set; }
        public int IdPais { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string VariableAbrev { get; set; }
        public string RenapoAbrev { get; set; }
        public string TresDigitosAbrev { get; set; }
        public int Clave { get; set; }
    }

    public class ActualizarEstado_Manejador : IRequestHandler<ActualizarEstadoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IRepositorioAsync<Pais> _repositorioPais;
        private readonly IMapper _mapper;

        public ActualizarEstado_Manejador(IRepositorioAsync<Estado> repositorioAsync,
                                          IRepositorioAsync<Pais> repositorioPais,
                                          IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._repositorioPais = repositorioPais;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarEstadoCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista el pais previamente capturado
            var existePais = await _repositorioPais.GetByIdAsync(request.IdPais, cancellationToken);
            if (existePais == null)
                throw new KeyNotFoundException($"No se encontro el Pais con el Id = { request.IdPais }");

            // se verifica que exista 
            Estado estado = await _repositorioAsync.GetByIdAsync(request.IdEstado, cancellationToken);
            if (estado == null)
                throw new KeyNotFoundException($"No se encuestra el registro con el Id = { request.IdEstado }");

            estado.Estatus = request.Estatus.Trim();
            estado.Nombre = request.Nombre.Trim();
            estado.VariableAbrev = request.VariableAbrev.Trim();
            estado.RenapoAbrev = request.RenapoAbrev.Trim();
            estado.TresDigitosAbrev = request.TresDigitosAbrev?.Trim();
            estado.Clave = request.Clave;

            await _repositorioAsync.UpdateAsync(estado, cancellationToken);

            return new Respuesta<int>(estado.IdEstado);
        }
    }
}
