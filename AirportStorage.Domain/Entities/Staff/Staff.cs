using AirportStorage.Domain.Abstract;
using AirportStorage.Domain.Entities.Types;

namespace AirportStorage.Domain.Entities.Staff
///<summary>
///Prototipo basico del personal
///</summary>
{
    public abstract class Staff
    #region Properties
    {///<summary>
     /// Datos personales del trabajador
     /// </summary>
        public Personal_inf Info { get; set; }
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
            Info.Name = nomb;
            Info.Id = id;
            Cargo = cargo;
            Exp = Experience.Noob;
            Years = 0;
        }

        #endregion



    }