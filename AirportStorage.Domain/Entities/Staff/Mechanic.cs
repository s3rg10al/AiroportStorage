﻿using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Staff
{
    public class Mechanic:Staff
    {
        #region Properties
        ///<summary>
        ///Cantidad de reparaciones realizadas por este mecanico
        /// </summary>
        public uint CantRep { get; set; }
        ///<summary>
        ///Pago por cada reparacion hecha
        ///</summary>
        public uint PagoxRep { get; set; }
        #endregion
        #region Methods
        ///<summary>
        ///Metodo que devueve el salario que debe coabrar el mecanico multiplicando Cantidad de reparaciones por el pago
        ///</summary>
        public uint Sueldo() { return CantRep * PagoxRep; }
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Mechanic"/>
        /// </summary>
        /// <param name="pagoXrep">Pago por reparacion</param>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cargo">Cargo que ocupa</param>

        public Mechanic(uint pagoXrep,string nomb,uint id,string cargo) : base(nomb,id,cargo)
        {
            PagoxRep = pagoXrep;
            CantRep=0;
        }

        #endregion

    }
}