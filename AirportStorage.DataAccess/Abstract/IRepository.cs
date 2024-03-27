using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Abstract
{
    public interface IRepository
    {
        
        /// <summary>
        /// Indica si el repositorio se encuentra en una transaccion
        /// </summary>
        bool IsInTransaction { get; }

        /// <summary>
        /// Inicia una transaccion
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Guarda los cambios de la transaccion actual y la cierra
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Elimina la transaccion actual sin guardar los cambios en BD 
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Guarda los cambios de la transaccion actual sin cerrarla
        /// </summary>
        void PartialCommit();




    }
}
