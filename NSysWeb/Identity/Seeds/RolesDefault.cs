using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class RolesDefault
    {
        public static async Task SeedAsync(UserManager<AplicacionUsuario> manejadorUsuario, RoleManager<IdentityRole> manejadorRoles)
        {
            // Seed de Roles y lo sacamos del Enum de aplication
            await manejadorRoles.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await manejadorRoles.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
