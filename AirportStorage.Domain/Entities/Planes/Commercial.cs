using AirportStorage.Domain.Entities.Hangar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un avion tipo comercial
    /// </summary>
    public class Commercial : Planes
    {
        #region Properties

        /// <summary>
        /// Capacidad de pasajeros maximos que permite el avion. Dato del fabricante
        /// </summary>
        public uint PassengersCapacity { get;}

        [NotMapped]
        /// <summary>
        /// hangar al que pertenece el avion comercial 
        /// </summary>
        public Hangar.Hangar Hangar  { get; set; }
        /// <summary>
        /// Identificador del Hangar al que pertece
        /// </summary>
        public int HangarId { get; set; }

        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Commercial"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje</param>
        /// <param name="capacidadPasajeros">capacidad de pasajeros</param>
        public Commercial(string modelo, string serialnumber, uint cantkmsPM, uint passengerscapacity , int hangarId) : base(modelo, serialnumber, cantkmsPM)
        {
            PassengersCapacity = passengerscapacity;
            HangarId = hangarId;
        
        }

        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Commercial () { }
        #endregion
    }
}
