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

        //public virtual DbSet<Asentamiento> Asentamientos { get; set; }

        public virtual DbSet<Asentamiento> Asentamientos { get; set; }
        public virtual DbSet<CorreoElectronico> CorreoElectronicos { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PersonaCorreoElectronico> PersonaCorreoElectronicos { get; set; }
        public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }
        public virtual DbSet<PersonaDocumento> PersonaDocumentos { get; set; }
        public virtual DbSet<PersonaTelefono> PersonaTelefonos { get; set; }
        public virtual DbSet<SysDominioCorreo> SysDominioCorreos { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }
        public virtual DbSet<AsentamientoTipo> TipoAsentamientos { get; set; }
        public virtual DbSet<DocumentoTipo> TipoDocumentos { get; set; }


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
                        entry.Entity.FechaModificacion = _fechaHoraServicio.Now;
                        entry.Entity.UsuarioModificacion = "";
                        break;
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = _fechaHoraServicio.Now;
                        entry.Entity.UsuarioCreacion = "";
                        entry.Entity.UsuarioModificacion = "";
                        entry.Entity.FechaModificacion = new System.DateTime(1900, 1, 1, 00, 00, 00, 000);
                        entry.Entity.EsHabilitado = true;
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
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
