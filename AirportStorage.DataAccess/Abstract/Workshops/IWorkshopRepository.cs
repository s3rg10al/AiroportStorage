using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AirportStorage.DataAccess.Abstract.Workshops
{
    /// <summary>
    /// Define las operaciones a ralizar sobre una base de datos de Workshop
    /// </summary>
    public interface IWorkshopRepository
    {
        /// <summary>
        /// Crea un Taller en BD
        /// </summary>
        /// <param name="ability">Capacidad del Taller</param>
        /// <returns></returns>
        Workshop CreateWorkshop(uint ability, Store store, Company company);

        Workshop? Get(int id);

        /// <summary>
        /// Obtien todos los Workshop en base de datos
        /// </summary>
        /// <returns> Workshop en Base de Datos</returns>
        IEnumerable<Workshop> GetAllWorkshop();

        /// <summary>
        /// Actualiza los parametros de un Workshop en BD
        /// </summary>
        /// <param name="workshop">Trabajador que se va actualizar</param>
        void Update(Workshop workshop);

        /// <summary>
        /// Elima un Workshop de BD
        /// </summary>
        /// <param name="workshop">workshop que se va a eliminar</param>
        void Delete(Workshop wtore);
    }
}


