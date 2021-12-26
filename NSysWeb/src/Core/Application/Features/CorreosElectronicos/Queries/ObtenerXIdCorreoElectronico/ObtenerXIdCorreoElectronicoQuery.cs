using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CorreosElectronicos.Queries.ObtenerXIdCorreoElectronico
{
    public class ObtenerXIdCorreoElectronicoQuery : IRequest<Respuesta<CorreoElectronicoDTO>>
    {
        public int IdCorreoElectronico { get; set; }
    }

    public class ObtenerXIdCorreoElectronico_Manejador : IRequestHandler<ObtenerXIdCorreoElectronicoQuery, Respuesta<CorreoElectronicoDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;

        public ObtenerXIdCorreoElectronico_Manejador(IRepositorioAsync<CorreoElectronico> repositoryAsync, IMapper mapper )
        {
            this._mapper = mapper;
            this._repositorioAsync = repositoryAsync;
        }

        public async Task<Respuesta<CorreoElectronicoDTO>> Handle(ObtenerXIdCorreoElectronicoQuery request, CancellationToken cancellationToken)
        {
            CorreoElectronico correoElectronico = await _repositorioAsync.GetByIdAsync(request.IdCorreoElectronico, cancellationToken);

            if (correoElectronico == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdCorreoElectronico }");

            CorreoElectronicoDTO correoElectronicoDTO = _mapper.Map<CorreoElectronicoDTO>(correoElectronico);

            return new Respuesta<CorreoElectronicoDTO>(correoElectronicoDTO);
        }
    }
}
