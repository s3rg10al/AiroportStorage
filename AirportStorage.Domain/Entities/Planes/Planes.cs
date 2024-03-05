using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un Avion
    /// </summary>
    public abstract class Planes : Entity // TODO: Revisar que todo este en inlges
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
        public FlightStatus Estado { get; set; }

        /// <summary>
        /// cantidad de kilometros totales recorridos por el avion
        /// </summary>

        public uint CantKmsTotales { get; set; }

        /// <summary>
        /// cantidad de kilometros totales recorridos por el avion desde su ultimo mantenimiento
        /// </summary>
        public uint CantKmsDesdeMant { get; set; }

        /// <summary>
        /// cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto 
        /// </summary>
        public uint CantKmsPlanMant { get;}

       
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Planes"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje </param>
        public Planes(string modelo, string serialnumber, uint cantkmsPM)
        {
            Model = modelo;
            SerialNumber = serialnumber;
            CantKmsPlanMant = cantkmsPM;
            CantKmsDesdeMant = 0;
            CantKmsTotales = 0;
            Estado = FlightStatus.Tierra;
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Planes () { }
        #endregion
    }
}
