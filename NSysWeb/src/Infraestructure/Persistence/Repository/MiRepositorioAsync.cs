using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository
{
    // aqui ya se usa e patron especificacion pero el que doce entityframeworkcore
    public class MiRepositorioAsync<T> : RepositoryBase<T>, IRepositorioAsync<T> where T : class
    {
        // este repositorio  se debe de alimentar de un dbcontext
        private readonly NSysWebDbContexto _dbContext;

        public MiRepositorioAsync(NSysWebDbContexto dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // hasta aqui tenermos nuestro repositorio implementacion del patron repositorio
    }
}
