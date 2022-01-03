using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Municipios.Commands.EliminarMunicipiosCommand
{
    public class EliminarMunicipioCommand : IRequest<Respuesta<int>>
    {
        public int IdMunicipio { get; set; }
    }

    public class EliminarMunicipio_Manejador : IRequestHandler<EliminarMunicipioCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Municipio> _repositorioAsync;

        public EliminarMunicipio_Manejador(IRepositorioAsync<Municipio> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarMunicipioCommand request, CancellationToken cancellationToken)
        {
            Municipio municipio = await _repositorioAsync.GetByIdAsync(request.IdMunicipio, cancellationToken);
            await _repositorioAsync.DeleteAsync(municipio,cancellationToken);

            return new Respuesta<int>(municipio.IdMunicipio);
        }
    }
}
