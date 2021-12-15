using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.SysDominiosCorreos.Queries.ObtenerXIdSysDominioCorreoQuery
{
    // No se pagina por que solo es un registro
    public class ObtenerXIdSysDominioCorreoQuery : IRequest<Respuesta<SysDominioCorreoDTO>>
    {
        public int IdSysDominioCorreo { get; set; }
    }

    public class ObtenerXIdSysDominioCorreo_Manejador : IRequestHandler<ObtenerXIdSysDominioCorreoQuery, Respuesta<SysDominioCorreoDTO>>
    {
        private readonly IRepositorioAsync<SysDominioCorreo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdSysDominioCorreo_Manejador(IRepositorioAsync<SysDominioCorreo> repositorioAsync,IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<SysDominioCorreoDTO>> Handle(ObtenerXIdSysDominioCorreoQuery request, CancellationToken cancellationToken)
        {
            SysDominioCorreo sysDominioCorreo = await _repositorioAsync.GetByIdAsync(request.IdSysDominioCorreo);

            if (sysDominioCorreo == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdSysDominioCorreo }");

            SysDominioCorreoDTO sysDominioCorreoDTO = _mapper.Map<SysDominioCorreoDTO>(sysDominioCorreo);

            return new Respuesta<SysDominioCorreoDTO>(sysDominioCorreoDTO);
        }
    }
}
