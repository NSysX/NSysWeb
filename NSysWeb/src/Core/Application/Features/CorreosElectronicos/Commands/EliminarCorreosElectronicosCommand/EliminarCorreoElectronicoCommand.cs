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

namespace Application.Features.CorreosElectronicos.Commands.EliminarCorreosElectronicosCommand
{
    public class EliminarCorreoElectronicoCommand : IRequest<Respuesta<int>>
    {
        public int IdCorreoElectronico { get; set; }
    }

    public class EliminarCorreoElectronico_Manejador : IRequestHandler<EliminarCorreoElectronicoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;
        private readonly IMapper _mapper;

        public EliminarCorreoElectronico_Manejador(IRepositorioAsync<CorreoElectronico> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(EliminarCorreoElectronicoCommand request, CancellationToken cancellationToken)
        {
            CorreoElectronico correoElectronico = await _repositorioAsync.GetByIdAsync(request.IdCorreoElectronico);

            if (correoElectronico == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdCorreoElectronico }");

            await _repositorioAsync.DeleteAsync(correoElectronico, cancellationToken);

            return new Respuesta<int>(correoElectronico.IdCorreoElectronico);
        }
    }
}
