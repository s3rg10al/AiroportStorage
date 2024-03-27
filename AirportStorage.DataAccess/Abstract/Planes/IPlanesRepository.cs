using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Planes;

namespace AirportStorage.DataAccess.Abstract.Plane
    
{
    /// <summary>
    /// Define las operaciones a ralizar sobre una base de datos de Aviones
    /// </summary>
    public interface  IPlanesRepository : IRepository
    {
        /// <summary>
        /// Crea un avion en BD
        /// </summary>
        /// <param name="modelo"> Modelo del avion</param>
        /// <param name="serialnumber">numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros en plan de mantenimiento</param>
        /// <param name="passengerscapacity">Capacidad de pasajeros del avion comercial</param>
        /// <param name="hangarId">identificador del hangar al que pertenece</param>
        /// <returns></returns>
        Commercial CreateCommercial(string modelo, string serialnumber, uint cantkmsPM, uint passengerscapacity, Hangar hangar);
        object CreateCommercial(string modelo, string serialnumber, uint cantkmsPM, uint passengerscapacity, Domain.Entities.Hangar.Hangar hangar);

        /// <summary>
        /// Crea un avion en BD
        /// </summary>
        /// <param name="modelo"> Modelo del avion</param>
        /// <param name="serialnumber">numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros en plan de mantenimiento</param>
        /// /// <param name="ownerId">id del propietario</param> //TODO: Revisar que la profe dijo que sno se pasara elñ id sino la clase completa a la que se va a hacer relacion
        /// <returns></returns>
        Jets CreateJets(string modelo, string serialnumber, uint cantkmsPM, Owner owner);

        /// <summary>
        /// Obtiene un avion
        /// </summary>
        /// <typeparam name="T">Tipo de avion a obtener</typeparam>
        /// <param name="id">identificador del avion</param>
        /// <returns>Avion solicitadoe de existir en BD, de lo contrario <see langword="null""/></returns>
        T? GetPlanes<T>(int id) where T : Planes;

        /// <summary>
        /// Obtien todos los Aviones en base de datos
        /// </summary>
        /// <returns>Aviones en Base de Datos</returns>
        IEnumerable<Planes> GetAllPlanes();

        /// <summary>
        /// Actualiza los parametros de un avion en BD
        /// </summary>
        /// <param name="planes">Avion que se va actualizar</param>
        void Update(Planes planes);

        /// <summary>
        /// Elima un avion de BD
        /// </summary>
        /// <param name="planes">avion que se va a eliminar</param>
        void Delete(Planes planes);

    }
}
