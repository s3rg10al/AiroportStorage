using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un Avion
    /// </summary>
    public class Planes // TODO: Hacer interface persona 
        //TODO: crear clase propietario
    {
       
        #region Properties

        /// <summary>
        /// Modelo del avion
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// numero de serie de fabricacion del avion
        /// </summary>
        public string SerialNumber { get; }

        /// <summary>
        /// estado actual del avion 
        /// </summary>
        public EstadoAvion Estado { get; set; }

        /// <summary>
        /// cantidad de kilometros totales recorridos por el avion
        /// </summary>

        public int CantKmsTotales { get; set; }

        /// <summary>
        /// cantidad de kilometros totales recorridos por el avion desde su ultimo mantenimiento
        /// </summary>
        public int CantKmsDesdeMant { get; set; }

        /// <summary>
        /// cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto 
        /// </summary>
        public int CantKmsPlanMant { get;}

        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Planes"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje </param>
        public Planes(string modelo, string serialnumber, int cantkmsPM)
        {
            Model = modelo;
            SerialNumber = serialnumber;
            CantKmsPlanMant = cantkmsPM;
            CantKmsDesdeMant = 0;
            CantKmsTotales = 0;
            Estado = EstadoAvion.Tierra;
        }

        #endregion
    }
}
