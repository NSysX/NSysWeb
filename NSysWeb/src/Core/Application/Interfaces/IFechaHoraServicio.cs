using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // para poder aregar es fecha creacion ultima modificacion que son los camposen comun
    // entre las entidades
    public interface IFechaHoraServicio
    {
        DateTime Now { get; }
    }
}
