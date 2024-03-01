using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un avion tipo comercial
    /// </summary>
    public class Comerciales : Planes
    {
        #region Properties

        /// <summary>
        /// Capacidad de pasajeros maximos que permite el avion. Dato del fabricante
        /// </summary>
        public uint CapacidadPasajeros {get;}

        /// <summary>
        /// Compañia a la que pertenece el avion comercial 
        /// </summary>
        public Compañia Company { get; set; }

        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Comerciales"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje</param>
        /// <param name="capacidadPasajeros">capacidad de pasajeros</param>
        public Comerciales(string modelo, string serialnumber, int cantkmsPM, int capacidadPasajeros) : base(modelo, serialnumber, cantkmsPM)
        {
            
            Compañia Company = " ";
        }
        #endregion
    }
}
