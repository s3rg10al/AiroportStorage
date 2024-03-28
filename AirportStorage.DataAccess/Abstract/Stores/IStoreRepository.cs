using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Abstract.Stores
{
    /// <summary>
    /// Define las operaciones a ralizar sobre una base de datos de Store
    /// </summary>
    public interface IStoreRepository : IRepository
    {
        /// <summary>
        /// Crea un Almacen en BD
        /// </summary>
        /// <param name="lastInv">Fecha del ultimo inventario</param>
        /// <returns></returns>
        Store CreateStore(uint cantPiezas, DateTime lastInv, Workshop workshop);

        Store? GetStore(int id);

        /// <summary>
        /// Obtien todos los Store en base de datos
        /// </summary>
        /// <returns>Trabajadores en Base de Datos</returns>
        IEnumerable<Store> GetAllStore();

        /// <summary>
        /// Actualiza los parametros de un Store en BD
        /// </summary>
        /// <param name="store">Trabajador que se va actualizar</param>
        void Update(Store store);

        /// <summary>
        /// Elima un store de BD
        /// </summary>
        /// <param name="store">avion que se va a eliminar</param>
        void Delete(Store store);
    }
}

