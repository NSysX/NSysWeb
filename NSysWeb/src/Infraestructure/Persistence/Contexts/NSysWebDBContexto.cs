using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    // Nuestra representacion de nuestra base de datos 
    // se tiene que modificarlo para que cada vez que se guarde en alguna tabla se guarde en automatico 
    // el creado por y el modificado por etc..
    public class NSysWebDbContexto : DbContext
    {
        private readonly IFechaHoraServicio _fechaHoraServicio;

        // se crea un constructor y se desactivan los rastreos de cambios tracking chancges
        // hacemos la inyecccion de la interfaz
        public NSysWebDbContexto(DbContextOptions<NSysWebDbContexto> opciones, IFechaHoraServicio fechaHoraServicio) : base(opciones)
        {
            // buenas practicas por que consume muchos recursos
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this._fechaHoraServicio = fechaHoraServicio;
        }

        public DbSet<Asentamiento> Asentamiento { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaDireccion> PersonaDireccion { get; set; }

        // Vamos a sobreescribir el metodo SaveChanges Async
        // lo que hace es guardar todos los cambios a nivel bd y hacer un commit
        // se cambia el cancell por el new CancellationToken
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // los entry entries
            // vamos a crear las entries de tipo auditable
            foreach (var entry in ChangeTracker.Entries<EntidadBaseAuditable>())
            {
                // esa entidad en su state
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Fecha_Modificacion = _fechaHoraServicio.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.Fecha_Creacion = _fechaHoraServicio.NowUtc;
                        break;

                    // Falta llenar en usuario creacion y usuario modificacion
                    // esto por que todavia no tenenmos usuarios 
                }   
            }
            // regresamos el metodo por defecto
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.HasAnnotation("","");
        }
    }
}
