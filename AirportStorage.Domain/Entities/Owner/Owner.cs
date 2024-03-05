using AirportStorage.Domain.Abstract;
using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Owner
{/// <summary>
/// Modela el propietario del jet
/// </summary>
    public class Owner : Entity, Person_inf
    {
        #region Properties
       
        public string Name { get; set; }
       
        [NotMapped]
        ///<summary>
        ///Lista de todos los jets que posee
        ///</summary>
        public List<Jets> Jets { get; set;}
        ///<summary>
        ///Cantidad total de sus jets
        ///</summary>
        public uint CantJets {  get; set; }

      
       public uint Id { get; } 

       public string Adress { get; set; }

       public uint PhoneNumb { get; set; }  
        
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Owner"/>
        /// </summary>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cantjets">Cantidad total de jets que posee</param>
        public Owner(string nomb, uint id, uint cantjets)
        {
            Name = nomb;
            Id = id;
            CantJets = cantjets;
            Jets = new List<Jets>();
          
        }

        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Owner() { }
        #endregion
    }
}
