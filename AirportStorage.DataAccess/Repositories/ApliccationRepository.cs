using AirportStorage.DataAccess.Abstract;
using AirportStorage.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : IRepository //TODO: Los contructores no llevan la introduccion del identificador. Se pasa el objeto completo y accedo a su ID

    {
        /// <summary>
        /// Cadena de conexio para generar la BD
        /// </summary>
        protected string _connectionString;

        /// <summary>
        /// Contexto medioante el cual se establece la conexion a BD.
        /// </summary>
        protected ApplicationContext? _context;

        public ApliccationRepository()
        {
        }

        public bool IsInTransaction => _context is not null;

        /// <summary>
        /// Inicializa un objeto ApplicattionRepository
        /// </summary>
        /// <param name="connectionString"></param>
        public void ApplicationRespository(string connectionString)
        {
            _connectionString = connectionString;
            _context = null;
        }

        public void BeginTransaction()
        {
            if (IsInTransaction)

                throw new InvalidOperationException("Cannot begin a new transaction before closing the current one");

            _context = new ApplicationContext(_connectionString);

            if (!_context.Database.CanConnect())
                _context.Database.Migrate();
        }

        public void CommitTransaction()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not an open transaction to commit");
            _context.SaveChanges();
            _context.Dispose();
            _context = null;

        }

        public void PartialCommit()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not open operation to commit");
            _context.SaveChanges();

        }

        public void RollbackTransaction()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not open operation to rollback.");
            _context?.Dispose();
            _context = null;
        }
    
    
    
    
    }
}
