using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Abstract.Staffs
{
    /// <summary>
    /// Define las operaciones a ralizar sobre una base de datos de Staff
    /// </summary>
    public interface IStaffRepository : IRepository
    {
        /// <summary>
        /// Crea una Persona en BD
        /// </summary>
        /// <param name="pagoXrep">Pago por reparacion</param>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cargo">Cargo que ocupa</param>
        /// <returns></returns>
        Mechanic CreateMechanic(uint pagoXrep, string nomb, uint id, string cargo, Workshop workshop);

        /// <summary>
        /// Crea una persona en BD
        /// </summary>
        /// <param name="pagoXhoras">Pago por horas trabajadas</param>
        /// <param name="pagoXhorasextras">Pago por horas extras</param>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cargo">Cargo que ocupa</param>
        /// <returns></returns>
        AssuranceStaff CreateAssuranceStaff(uint pagoXhoras, uint pagoXhorasextras, string nomb, uint id, string cargo,Hangar hangar);

        /// <summary>
        /// Obtiene una persona
        /// </summary>
        /// <typeparam name="T">Tipo de trabajador a obtener</typeparam>
        /// <param name="id">identificador del trabajador</param>
        /// <returns>Trabajador solicitado de existir en BD, de lo contrario <see langword="null""/></returns>
        T? GetStaff<T>(int id) where T : Staff;

        /// <summary>
        /// Obtien todos los Trabajadores en base de datos
        /// </summary>
        /// <returns>Trabajadores en Base de Datos</returns>
        IEnumerable<Staff> GetAllStaff();

        /// <summary>
        /// Actualiza los parametros de un trabajador en BD
        /// </summary>
        /// <param name="staff">Trabajador que se va actualizar</param>
        void Update(Staff staff);

        /// <summary>
        /// Elima un trabajador de BD
        /// </summary>
        /// <param name="staff">avion que se va a eliminar</param>
        void Delete(Staff staff);
        
   
    }
}
