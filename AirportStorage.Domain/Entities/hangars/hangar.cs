using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.hangars
{
    public class Hangar 
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
        /// <summary>
        /// lista de aviones
        /// </summary>
        //public List<Avion>aviones { get; }
        /// <summary>
        /// lista que contiene el personal de aseguramiento de cada hangar
        /// </summary>
        //public List<PersonalAseguramiento> personal { get; }


        #endregion


        #region methods
        /// <summary>
        /// una funcion que devuelve la cantidad personal de aseguramiento osea cantidad de trabajadores 
        /// </summary>
        /// <returns></returns>
        /*public int cantPersonalAseguramiento()
        {
            return personal.Count;
        }

        public int cantAviones()
        {
            return aviones.Count;
        }*/

        #endregion

        #region construct
        /// <summary>
        /// constructor de la clase Hangar 
        /// </summary>
        /// <param name="InitialCantMax">se debe iniciar la cantidad maxima de aviones</param>
        public Hangar(int InitialCantMax)
        {
            capMax = InitialCantMax;
            isfull = false;
           // aviones = new List<Avion>();
           //personal = new List<PersonalAseguramiento>();
        }
        #endregion

    }
}
