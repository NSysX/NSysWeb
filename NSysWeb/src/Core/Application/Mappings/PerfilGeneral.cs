using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class PerfilGeneral : Profile
    {
        public PerfilGeneral()
        {
            // vamos a ir agrupando todos los mapeos de comandos
            #region MapeoEstadoCivil
            CreateMap<InsertarEstadoCivilCommand, EstadoCivil>();
            #endregion

        }
    }
}
