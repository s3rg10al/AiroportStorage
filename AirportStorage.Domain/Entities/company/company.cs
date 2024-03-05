using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.hangars;
using AirportStorage.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.company
{
    public class Company : Entity


    {
        #region propieties

        /// <summary>
        /// nombre del pais al que pertenece la compañia
        /// </summary>
        public string Pais { get; set; }

        /// <summary>
        /// personal total de la compañia
        /// </summary>
        public int PersonalTotal { get; }

        /// <summary>
        /// define el tipo de propiedad si privada o publica
        /// </summary>
       // public OwnerType owner;


        /// <summary>
        /// lista de hangares
        /// </summary>
        [NotMapped]
        public List<Hangar> Hangars { get; }


        /// <summary>
        /// lista de talleres que posee la comp
        /// </summary>
        public List<Workshop.Workshop> Workshops { get; set; }

        public Propiety companyType;

        
        #endregion


        #region methods
        public int CantHangares()
        {
            return Hangars.Count;
        }

        //public int TotalAviones()
        //{
        //    return for...;
        //}



        #endregion

        #region construct
        /// <summary>
        /// constructor de la clase company que establece el pais donde se encuentraw
        /// </summary>
        /// <param name="InitialPais">pais al que pertenece la compañia</param>
        public Company(string InitialPais)
        {
            Pais= InitialPais;
            Hangars= new List<Hangar>();
            Workshops = new List<Workshop.Workshop>();
        }
        
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>
        
        protected Company() { } 

        #endregion

    }
}
