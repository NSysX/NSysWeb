﻿using Application.Interfaces;
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

namespace Application.Features.Documentos.Commands.ActualizarDocumentosCommand
{
    public class ActualizarDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdDocumento { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Foto { get; set; }
    }

    public class ActualizarDocumento_Manejador : IRequestHandler<ActualizarDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Documento> _repositorioAsyc;
        // private readonly IMapper _mapper;

        public ActualizarDocumento_Manejador(IRepositorioAsync<Documento> repositorioAsyc,
                                             IMapper mapper)
        {
            this._repositorioAsyc = repositorioAsyc;
            //this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarDocumentoCommand request, CancellationToken cancellationToken)
        {
            // verificamos si existe el registro del id
            Documento documento = await _repositorioAsyc.GetByIdAsync(request.IdDocumento);

            if (documento == null)
                throw new KeyNotFoundException($"No se Encontro el Registro con el Id = { request.IdDocumento }");

            documento.IdDocumentoTipo = request.IdDocumentoTipo;
            documento.Estatus = request.Estatus;
            documento.CodigoUnico = request.CodigoUnico;
            documento.Foto = request.Foto;

            await _repositorioAsyc.UpdateAsync(documento);

            return new Respuesta<int>(documento.IdDocumento);
        }
    }
}
