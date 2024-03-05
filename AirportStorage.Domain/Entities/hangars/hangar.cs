using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Planes;
using AirportStorage.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Hangar
{
    public class Hangar : Entity 
    {
        #region propierties
        
        /// <summary>
        /// devuelve la cantidad maxima de aviones que almacena
        /// </summary>
        public int capMax;
        /// <summary>
        /// dice si esta lleno el hangar osea si alcanzo la cantmax
        /// </summary>
        public bool isfull;
        
        [NotMapped]
        /// <summary>
        /// lista de aviones
        /// </summary>
        public List<Commercial> CommercialsPlanes { get; set; }
        
        [NotMapped]
        /// <summary>
        /// lista que contiene el personal de aseguramiento de cada hangar
        /// </summary>
        public List<AssuranceStaff> assuranceStaffs { get; set; }

        [NotMapped]
        /// <summary>
        /// Relacion con la compañia a que pertece
        /// </summary>
        public Company Company { get; set; }
        
        /// <summary>
        /// Identificxador de la compañia
        /// </summary>
        public int CompanyId { get; set; }

        #endregion
            

        #region methods
        /// <summary>
        /// una funcion que devuelve la cantidad personal de aseguramiento osea cantidad de trabajadores 
        /// </summary>
        /// <returns></returns>
        public int cantPersonalAseguramiento()
        {
            return assuranceStaffs.Count;
        }

        public int cantAviones()
        {
            return CommercialsPlanes.Count;
        }

        #endregion

        #region construct
        /// <summary>
        /// constructor de la clase Hangar 
        /// </summary>
        /// <param name="InitialCantMax">se debe iniciar la cantidad maxima de aviones</param>
        public Hangar(int InitialCantMax, int companyId)
        {
            capMax = InitialCantMax;
            isfull = false;
           CommercialsPlanes = new List<Commercial>();
           assuranceStaffs = new List<AssuranceStaff>();
            CompanyId = companyId;
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Hangar() { }
        #endregion

    }
}
