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

namespace Application.Features.CorreosElectronicos.Commands.InsertarCorreosElectronicosCommand
{
    public class InsertarCorreoElectronicoCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoCorreo { get; set; }
    }

    public class InsertarCorreoElectronico_Manejador : IRequestHandler<InsertarCorreoElectronicoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarCorreoElectronico_Manejador(IRepositorioAsync<CorreoElectronico> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarCorreoElectronicoCommand request, CancellationToken cancellationToken)
        {
            CorreoElectronico correoElectronico = _mapper.Map<CorreoElectronico>(request);
            CorreoElectronico respuesta = await _repositorioAsync.AddAsync(correoElectronico, cancellationToken);

            return new Respuesta<int>(respuesta.IdCorreoElectronico);
        }
    }
}
