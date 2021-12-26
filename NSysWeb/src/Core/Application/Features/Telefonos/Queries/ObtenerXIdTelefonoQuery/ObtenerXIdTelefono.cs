using Application.DTOs;
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

namespace Application.Features.Telefonos.Queries.ObtenerXIdTelefonoQuery
{
    public class ObtenerXIdTelefonoQuery : IRequest<Respuesta<TelefonoDTO>>
    {
        public int IdTelefono { get; set; }
    }

    public class ObtenerXIdTelefonoQuery_Manejador : IRequestHandler<ObtenerXIdTelefonoQuery, Respuesta<TelefonoDTO>>
    {
        private readonly IRepositorioAsync<Telefono> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdTelefonoQuery_Manejador(IRepositorioAsync<Telefono> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }


        public async Task<Respuesta<TelefonoDTO>> Handle(ObtenerXIdTelefonoQuery request, CancellationToken cancellationToken)
        {
            Telefono telefono = await _repositorioAsync.GetByIdAsync(request.IdTelefono, cancellationToken);

            if (telefono == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdTelefono }");

            TelefonoDTO telefonoDTO = _mapper.Map<TelefonoDTO>(telefono);

            return new Respuesta<TelefonoDTO>(telefonoDTO);
        }
    }
}