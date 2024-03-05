using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Types
{
    /// <summary>
    /// nivel de lujo que presenta un jet
    /// </summary>
    public enum LuxuryLevel
    {
        /// <summary>
        /// alto, clasificacion del nuvel de lujo de los jets
        /// </summary>
        Alto,
        /// <summary>
        /// medio, clasificacion del nuvel de lujo de los jets
        /// </summary>
        Medio,
        /// <summary>
        /// estanar, clasificacion del nuvel de lujo de los jets
        /// </summary>
        Estandar,


        // el mas basico es estandar porque un jet privado ya trae implicito cierto lujo
    }
}
