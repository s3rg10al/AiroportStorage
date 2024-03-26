using AirportStorage.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Store

///<summary>
///Modela un Almacen
///</summary>
{ 
     public class Store : Entity
    { 
        #region Properties
        /// <summary>
        /// Cantidad de piezas en existencia en el Almacen
        /// </summary>
         public uint CantPiezas { get; set; }
        ///<summary>
        ///Fecha del ultimo inventario
        ///</summary>
        public DateTime UltimoInv { get; set; }
       
        [NotMapped]
        /// <summary>
        /// Taller al que pertenece
        /// </summary>
        public Workshop.Workshop Workshop { get; set; }
        
        public int WorkshopId { get; set; }
        #endregion

        #region Constructor
        ///<sumary>
        ///Inicializa un objeto <see cref="Store"/>
        ///</sumary>
        /// <param name="lastInv">Fecha del ultimo inventario</param>
        public Store( uint cantPiezas, DateTime lastInv, Workshop.Workshop workshop) { 
            UltimoInv = lastInv;
            CantPiezas = 0;
            WorkshopId = workshop.Id;
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Store () { }
        #endregion


    }



}

