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

namespace Application.Features.CorreosElectronicos.Commands.ActualizarCorreosElectronicosCommand
{
    public class ActualizarCorreoElectronicoCommand : IRequest<Respuesta<int>>
    {
        public int IdCorreoElectronico { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoCorreo { get; set; }
    }

    public class ActualizarCorreoElectronico_Manejador : IRequestHandler<ActualizarCorreoElectronicoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizarCorreoElectronico_Manejador(IRepositorioAsync<CorreoElectronico> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarCorreoElectronicoCommand request, CancellationToken cancellationToken)
        {
            CorreoElectronico correoElectronico = await _repositorioAsync.GetByIdAsync(request.IdCorreoElectronico, cancellationToken);

            if (correoElectronico == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdCorreoElectronico }");

            correoElectronico.Estatus = request.Estatus;
            correoElectronico.Correo = request.Correo;
            correoElectronico.TipoCorreo = request.TipoCorreo;

            await _repositorioAsync.UpdateAsync(correoElectronico, cancellationToken);

            return new Respuesta<int>(correoElectronico.IdCorreoElectronico);
        }
    }
}
