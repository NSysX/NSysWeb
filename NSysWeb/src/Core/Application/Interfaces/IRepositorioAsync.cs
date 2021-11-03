using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // ardalis especification tiene todo el patron repositorio implementado
    // para no estar reinventando la rueda
    public interface IRepositorioAsync<T> : IRepositoryBase<T> where T : class
    {
    }

    public interface ILeerRepositorioAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
