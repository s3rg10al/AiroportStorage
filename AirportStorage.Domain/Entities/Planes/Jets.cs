using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportStorage.Domain.Entities.Owner;

namespace AirportStorage.Domain.Entities.Planes
{
    /// <summary>
    /// Modela un avion tipo Jet
    /// </summary>
    public class Jets : Planes
    {
        #region Propeties
        public LuxuryLevel LuxuryLevel { get; set; }
       
        [NotMapped]
        /// <summary>
        /// Propietario del Jet
        /// </summary>
        public Owner.Owner Owner { get; set; }

        /// <summary>
        /// Identificacion del Propietario
        /// </summary>
        public int OwnerId { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Jets"/>
        /// </summary>
        /// <param name="modelo">Modelo del avion</param>
        /// <param name="serialnumber">Numero de serie del avion</param>
        /// <param name="cantkmsPM">cantidad de kilometros a los cuales al avion se le debe realizar mantenimineto kilometraje</param>
        /// <param name="propietario">propietario</param>

        public Jets(string modelo, string serialnumber, uint cantkmsPM, Owner.Owner owner) : base(modelo, serialnumber, cantkmsPM)
        {
            
            LuxuryLevel = LuxuryLevel.Estandar;
            OwnerId = owner.CI;
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Jets () { }
        #endregion
    }
}
