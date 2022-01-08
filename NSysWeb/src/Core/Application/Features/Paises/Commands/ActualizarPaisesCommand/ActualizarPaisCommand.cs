using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Paises.Commands.ActualizarPaisesCommand
{
    public class ActualizarPaisCommand : IRequest<Respuesta<int>>
    {
        public int IdPais { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class ActualizarPais_Manejador : IRequestHandler<ActualizarPaisCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Pais> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizarPais_Manejador(IRepositorioAsync<Pais> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarPaisCommand request, CancellationToken cancellationToken)
        {
            Pais pais = await _repositorioAsync.GetByIdAsync(request.IdPais, cancellationToken);
            if (pais == null)
                throw new KeyNotFoundException($"No Existe el Pais con Id = { request.IdPais }");

            pais.Estatus = request.Estatus;
            pais.Nombre = request.Nombre;
            pais.Abreviatura = request.Abreviatura;

            await _repositorioAsync.UpdateAsync(pais, cancellationToken);

            return new Respuesta<int>(pais.IdPais);
        }
    }
}
