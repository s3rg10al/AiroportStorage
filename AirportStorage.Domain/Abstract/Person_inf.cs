using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Abstract
///<summary>
///Interfaz dedicada a guardar datos personales de todo tipo de persona
///</summary>
{
    public interface Person_inf
    {
        #region Propieties
        ///<summary>
        /// Nombre de la persona
        /// </summary>
        public string Name { get; set; }
        ///<summary>
        /// Numero de identidad de la persona
        ///</summary>
        public uint Id { get; }

        ///<summary>
        /// Direccion de la persona
        ///</summary>
         public string Adress { get; set; }

        ///<summary>
        /// Numero de Telefono de la persona
        ///</summary>
        public uint PhoneNumb { get; set; }

        #endregion
    }
}
        

