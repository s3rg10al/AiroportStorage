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
   public  interface Personal_inf
    {
        
        ///<sumary>
        /// Nombre de la persona
        /// </sumary>
        string Name { get; set; }
        ///<sumary>
        ///Numero de identidad de la persona
        ///</sumary>
        uint Id { set; }
        ///<summary>
        ///Direccion de la persona
        ///</summary>
        string Adress { get; set; }
        ///<sumary>
        ///Numero de Telefono de la persona
        ///</sumary>
        uint PhoneNumb { get; set; }


    }
        

