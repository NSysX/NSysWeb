using Application.DTOs;
using Application.Exceptions;
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

namespace Application.Features.EstadosCiviles.Queries.ObtenerXIdEstadoCivil
{
    public class ObtenerXIdEstadoCivilQuery : IRequest<Respuesta<EstadoCivilDTO>>
    {
        public int IdEstadoCivil { get; set; }

        public class ObtenerXIdEstadoCivil_Manejador : IRequestHandler<ObtenerXIdEstadoCivilQuery, Respuesta<EstadoCivilDTO>>
        {
            private readonly IRepositorioAsync<EstadoCivil> _respositorioEstadoCivil;
            private readonly IMapper _mapper;

            public ObtenerXIdEstadoCivil_Manejador(IRepositorioAsync<EstadoCivil> respositorioEstadoCivil, IMapper mapper )
            {
                this._respositorioEstadoCivil = respositorioEstadoCivil;
                this._mapper = mapper;
            }

            public async Task<Respuesta<EstadoCivilDTO>> Handle(ObtenerXIdEstadoCivilQuery request, CancellationToken cancellationToken)
            {
                EstadoCivil estadoCivil = await _respositorioEstadoCivil.GetByIdAsync(request.IdEstadoCivil);

                if (estadoCivil == null)
                    throw new KeyNotFoundException($"No se encontro el Registro con el Id = {request.IdEstadoCivil}");

                EstadoCivilDTO estadoCivilDTO = _mapper.Map<EstadoCivilDTO>(estadoCivil);

                return new Respuesta<EstadoCivilDTO>(estadoCivilDTO);
            }
        }

    }
}
