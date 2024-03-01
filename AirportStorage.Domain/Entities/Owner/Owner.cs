using AirportStorage.Domain.Abstract;
using AirportStorage.Domain.Entities.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Owner
{/// <summary>
/// Modela el propietario del jet
/// </summary>
    internal class Owner
    {
        #region Properties
        ///<summary>
        /// Datos personales del dueno
        /// </summary>
        public Personal_inf PersonInf{ get; set; }
        ///<summay>
        ///Lista de todos los jets que posee
        ///</summay>
        public List<Jets> jets { get; set;}
        ///<summary>
        ///Cantidad total de sus jets
        ///</summary>
        public uint CantJets {  get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Owner"/>
        /// </summary>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cantjets">Cantidad total de jets que posee</param>
        public Owner(string nomb,uint id,uint cantjets) {
            PersonInf.Name = nomb;
            PersonInf.Id = id;
            CantJets = cantjets;
            jets = new List<Jets>();
        }
    }
}
