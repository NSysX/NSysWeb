using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.CorreosElectronicos;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CorreosElectronicos.Queries.ListarCorreosElectronicos
{
    public class ListarCorreosElectronicosQuery : IRequest<RespuestaPaginada<List<CorreoElectronicoDTO>>>
    {
        public int RegistrosXPagina { get; set; }
        public int NumeroDePagina { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
    }

    public class ListarCorreosElectronicos_Manejador : IRequestHandler<ListarCorreosElectronicosQuery, RespuestaPaginada<List<CorreoElectronicoDTO>>>
    {
        private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarCorreosElectronicos_Manejador(IRepositorioAsync<CorreoElectronico> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<CorreoElectronicoDTO>>> Handle(ListarCorreosElectronicosQuery request, CancellationToken cancellationToken)
        {
            List<CorreoElectronico> correoElectronico = await _repositorioAsync.ListAsync(new CorreosElectronicosXParametrosSpec(request.RegistrosXPagina, request.NumeroDePagina, request.Estatus, request.Correo));

            List<CorreoElectronicoDTO> correoElectronicoDTO = _mapper.Map<List<CorreoElectronicoDTO>>(correoElectronico);

            return new RespuestaPaginada<List<CorreoElectronicoDTO>>(correoElectronicoDTO, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}
