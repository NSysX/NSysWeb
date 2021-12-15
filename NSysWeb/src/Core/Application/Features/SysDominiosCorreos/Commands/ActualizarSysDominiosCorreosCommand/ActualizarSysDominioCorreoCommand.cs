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

namespace Application.Features.SysDominiosCorreos.Commands.ActualizarSysDominiosCorreosCommand
{
    public class ActualizarSysDominioCorreoCommand : IRequest<Respuesta<int>>
    {
        public int IdSysDominioCorreo { get; set; }
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }

    public class ActualizarSysDominio_Manejador : IRequestHandler<ActualizarSysDominioCorreoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<SysDominioCorreo> _reposiotorioAsync;
        private readonly IMapper _mapper;

        public ActualizarSysDominio_Manejador(IRepositorioAsync<SysDominioCorreo> reposiotorioAsync , IMapper mapper)
        {
            this._reposiotorioAsync = reposiotorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarSysDominioCorreoCommand request, CancellationToken cancellationToken)
        {
            // verificamos si existe el id a modificar
            SysDominioCorreo sysDominioCorreo = await _reposiotorioAsync.GetByIdAsync(request.IdSysDominioCorreo);

            if (sysDominioCorreo == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdSysDominioCorreo }");

            // si lo encuentra le asignamos los valores manual por que son pocos
            sysDominioCorreo.Estatus = request.Estatus;
            sysDominioCorreo.Dominio = request.Dominio;

            await _reposiotorioAsync.UpdateAsync(sysDominioCorreo, cancellationToken);
            return new Respuesta<int>(sysDominioCorreo.IdSysDominioCorreo);
        }
    }
}
