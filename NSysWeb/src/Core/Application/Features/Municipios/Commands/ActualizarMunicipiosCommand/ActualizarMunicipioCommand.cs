using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Municipios.Commands.ActualizarMunicipiosCommand
{
    public class ActualizarMunicipioCommand : IRequest<Respuesta<int>>
    {
        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int Clave { get; set; }
    }

    public class ActualizarMunicipio_Manejador : IRequestHandler<ActualizarMunicipioCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Municipio> _repositoryAsync;
        private readonly IMapper _mapper;

        public ActualizarMunicipio_Manejador(IRepositorioAsync<Municipio> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarMunicipioCommand request, CancellationToken cancellationToken)
        {
            Municipio municipio = await _repositoryAsync.GetByIdAsync(request.IdMunicipio, cancellationToken);

            if (municipio == null)
                throw new KeyNotFoundException($"No se Encontro el Registro con el Id = { request.IdMunicipio }");

            municipio.IdEstado = request.IdEstado;
            municipio.Estatus = request.Estatus;
            municipio.Nombre = request.Nombre;
            municipio.Abreviatura = request.Abreviatura;
            municipio.Clave = request.Clave;

            await _repositoryAsync.UpdateAsync(municipio, cancellationToken);

            return new Respuesta<int>(municipio.IdMunicipio);
        }
    }
}