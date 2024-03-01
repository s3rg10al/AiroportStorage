using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un avion tipo Jet
    /// </summary>
    public class Jets : Planes
    {
        #region Propeties
        public NivelDeLujo NivelDeLujo { get; set; }

        public string Propietario { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Jets"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje</param>
        /// <param name="propietario">propietario</param>

        public Jets(string modelo, string serialnumber, int cantkmsPM, string propietario = "") : base(modelo, serialnumber, cantkmsPM)
        {
            Propietario = propietario;
            NivelDeLujo = NivelDeLujo.Estandar;
        }
        #endregion
    }
}
