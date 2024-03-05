using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.hangars;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Workshop
/// <summary>
/// Modela un Taller
///  </summary>
{
    public class Workshop : Entity
    {
        #region Properties
        [NotMapped]
        ///<summary>
        ///Almacen del Taller
        ///</summary>
        public Store.Store Store {  get; set; }
        /// <summary>
        /// identificador de la tienda
        /// </summary>
        public int StoreId { get; set; }

        [NotMapped]
        ///<summary>
        ///Lista de los Mecanicos que trabajan en ese taller
        ///</summary>
        public List<Mechanic> Mech { set; get; }
        ///<summary>
        ///Capacidad maxima de aviones en el taller
        ///</summary>
        public uint Ability {  get; set; }
        ///<summary>
        ///Te indica si hay capacidad pra otro avion en el taller o no
        ///</summary>
        public bool IsAbility {  get; set; }
        ///<summary>
        ///Que tipo de taller es
        ///</summary>
        public Speciality specialty { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        ///Inicializa un objeto <see cref="Workshop"/>
        /// </summary>
        /// <param name="ability">Capacidad del Taller</param>
        public Workshop(uint ability)
        {
            Ability=ability;
            IsAbility= true;
             Mech = new List<Mechanic>();
            
            
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Workshop () { }
        #endregion





    }
}
