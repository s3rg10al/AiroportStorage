using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Planes;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System.Drawing;
using AirportStorage.DataAccess.FluentConfigurations;
using Microsoft.Data.Sqlite;

namespace AirportStorage.DataAccess.Concrete
{
    /// <summary>
    /// Define la estructura de la base de datos de la aplicación.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        //Región destinada a la declaración de las tablas de las entidades base
        #region Tables 

        /// <summary>
        /// Tabla de compañias.
        /// </summary>
        public DbSet<Company> Companies { get; set; }
        /// <summary>
        /// tabla de propietarios
        /// </summary>
        public DbSet<Owner> Owners { get; set; }
        /// <summary>
        /// Tabla de hangares.
        /// </summary>
        public DbSet<Hangar> Hangars { get; set; }
        /// <summary>
        /// Tabla de aviones.
        /// </summary>
        public DbSet<Planes> Planes { get; set; }
        /// <summary>
        /// Tabla de personal.
        /// </summary>
        public DbSet<Staff> Staff { get; set; }
        /// <summary>
        /// Tabla de taller.
        /// </summary>
        public DbSet<Workshop> Workshop { get; set; }

        /// <summary>
        /// tabla de almacen
        /// </summary>
        public DbSet<Store> Store { get; set; }

        #endregion


        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public ApplicationContext()
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Base classes mapping

            modelBuilder.Entity<Company>().ToTable("Company");

            modelBuilder.Entity<Hangar>().ToTable("Hangar");

            modelBuilder.Entity<Planes>().ToTable("Planes");

            modelBuilder.Entity<Staff>().ToTable("Staff");

            modelBuilder.Entity<Workshop>().ToTable("Workshop");

            modelBuilder.Entity<Store>().ToTable("Store");


            #endregion

            modelBuilder.ApplyConfiguration(new AssuranceStaffFluentConfiguration());
            modelBuilder.ApplyConfiguration(new CommercialFluentConfiguration());
            modelBuilder.ApplyConfiguration(new JetsFluentConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicFluentConfiguration());


        }


        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

    }

    /// <summary>
    /// Habilita características en tiempo de diseño de la base de datos de la aplicación.
    /// Ej: Migraciones.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            try
            {
                var connectionString ="Data Source = AirportStorage.sqlite";
                optionsBuilder.UseSqlite(connectionString);
            }
            catch (Exception)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
                throw;
            }

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
