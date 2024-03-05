using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Types
{
    /// <summary>
    /// Estado de vuelo en el que se encuentra un avion
    /// </summary>
    public enum FlightStatus
    {
        /// <summary>
        /// tierra, posible estado de un avion
        /// </summary>
        Tierra,
        /// <summary>
        /// volando, posible estado de un avion
        /// </summary>
        Volando,
        /// <summary>
        /// mantenimiento, posible estado de un avion
        /// </summary>
        Mantenimiento,

    }
}
