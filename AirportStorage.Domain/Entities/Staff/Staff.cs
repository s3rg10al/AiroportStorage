using AirportStorage.Domain.Abstract;
using AirportStorage.Domain.Entities.Common;
using AirportStorage.Domain.Entities.Types;

namespace AirportStorage.Domain.Entities.Staff
///<summary>
///Prototipo basico del personal
///</summary>
{
    public abstract class Staff : Entity , Person_inf
    #region Properties
    {
        ///<summary>
        ///Experiencia del trabajador
        ///</summary>
        public Experience Exp { get; set; }
        ///<sumary>
        ///Cantidad de anos trabajados
        ///</sumary>
        public uint Years { get; set; }
        ///<sumary>
        ///Cargo que ocupa
        ///</sumary>
        public string Cargo { get; set; }
        ///<sumary>
        ///Salario que gana este trabajador
        ///</sumary>
        public uint Sueldo { get; set; }

        public string Name { get; set; }

        public uint CI { get; }

        public string Adress { get; set; }

        public uint PhoneNumb { get; set; }

        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Staff"/>
        /// </summary>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cargo">Cargo que ocupa </param>
        public Staff(string nomb, uint id, string cargo)
        {
            Name = nomb;
            CI = id;
            Cargo = cargo;
            Exp = Experience.Noob;
            Years = 0;
        }
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected Staff () { }
        #endregion



    }
}