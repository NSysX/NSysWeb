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

namespace Application.Features.SysDominiosCorreos.Commands.InsertarSysDominiosCorreosCommand
{
    public class InsertarSysDominioCorreoCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }

    public class InsertarSysDominio_Manejador : IRequestHandler<InsertarSysDominioCorreoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<SysDominioCorreo> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarSysDominio_Manejador(IRepositorioAsync<SysDominioCorreo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarSysDominioCorreoCommand request, CancellationToken cancellationToken)
        {
            SysDominioCorreo sysDominioCorreo = _mapper.Map<SysDominioCorreo>(request);
            var resultado = await _repositorioAsync.AddAsync(sysDominioCorreo,cancellationToken);
            return new Respuesta<int>(resultado.IdSysDominioCorreo);
        }
    }
}
