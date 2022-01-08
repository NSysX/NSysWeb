using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Estados.Commands
{
    public class InsertarEstadoCommand : IRequest<Respuesta<int>>
    {
        public int IdPais { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string VariableAbrev { get; set; }
        public string RenapoAbrev { get; set; }
        public string TresDigitosAbrev { get; set; }
        public int Clave { get; set; }
    }

    public class InsertarEstado_Manejador : IRequestHandler<InsertarEstadoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IRepositorioAsync<Pais> _repositorioPais;
        private readonly IMapper _mapper;

        public InsertarEstado_Manejador(IRepositorioAsync<Estado> repositorio,
                                        IRepositorioAsync<Pais> repositorioPais,                           
                                        IMapper mapper)
        {
            this._repositorioAsync = repositorio;
            this._repositorioPais = repositorioPais;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarEstadoCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista el pais
            var paisExiste = await _repositorioPais.GetByIdAsync(request.IdPais, cancellationToken);
            if (paisExiste == null)
                throw new KeyNotFoundException($"No se encontro el Pais con el Id = { request.IdPais }");

            Estado estado = _mapper.Map<Estado>(request);
            var resultado = await _repositorioAsync.AddAsync(estado, cancellationToken);
            return new Respuesta<int>(resultado.IdEstado);
        }
    }
}
