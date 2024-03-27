using AirportStorage.Domain.Entities.Owner;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Abstract.Owners
{
    /// <summary>
    /// Define las operaciones a ralizar sobre una base de datos de Owner
    /// </summary>
    public interface  IOwnerRepository
    {
        /// <summary>
        /// Crea un Dueno en BD
        /// </summary>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cantjets">Cantidad total de jets que posee</param>
        /// <returns></returns>
        Owner CreateOwner(string nomb, uint id, uint cantjets);

        Owner? Get(int id);
       
        /// <summary>
        /// Obtien todos los Owners en base de datos
        /// </summary>
        /// <returns>Trabajadores en Base de Datos</returns>
        IEnumerable<Owner> GetAllOwner();

        /// <summary>
        /// Actualiza los parametros de un owner en BD
        /// </summary>
        /// <param name="owner">Trabajador que se va actualizar</param>
        void Update(Owner owner);

        /// <summary>
        /// Elima un owner de BD
        /// </summary>
        /// <param name="owner">avion que se va a eliminar</param>
        void Delete(Owner owner);
    }
}
