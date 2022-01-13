using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Contexto
{
    public class IdentityContexto : IdentityDbContext<AplicacionUsuario>
    {
        public IdentityContexto(DbContextOptions<IdentityContexto> opt) : base(opt)
        {

        }
    }
}
