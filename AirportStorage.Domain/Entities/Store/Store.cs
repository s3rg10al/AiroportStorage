using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Store { 
    ///<summary>
    ///Modela un Almacen
    ///</summary>
     public class Store { 
        #region Properties
        /// <summary>
        /// Cantidad de piezas en existencia en el Almacen
        /// </summary>
         public uint CantPiezas { get; set; }
        ///<summary>
        ///Fecha del ultimo inventario
        ///</summary>
        public DateTime UltimoInv { get; set; }
        #endregion

        #region Constructor
        ///<sumary>
        ///Inicializa un objeto <see cref="Store"/>
        ///</sumary>
        /// <param name="lastInv">Fecha del ultimo inventario</param>
        public Store( uint cantPiezas, DateTime lastInv ) { 
            UltimoInv = lastInv;
            CantPiezas = 0;
        }
        #endregion


    }



}

