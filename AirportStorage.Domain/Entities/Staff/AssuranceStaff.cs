using AirportStorage.Domain.Entities.Hangar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.Domain.Entities.Staff
{/// <summary>
/// Clase que modela al personal de aseguramiento
/// </summary>
    public class AssuranceStaff : Staff
    {
        #region Properties
        /// <summary>
        /// Cantidas de horas que trabajo en horario laboral
        /// </summary>
        public uint CantHorasTrabajadas {  get; set; }
        ///<summary>
        ///Cantidad de horas extras trabajadas
        ///</summary>
        public uint CantHorasExtras {  get; set; }
        ///<summary>
        ///Pago por horas trabajadas en horario laboral
        ///</summary>
        public uint PagoxHoras {  get; set; }
        ///<summary>
        ///Pago por horas extras
        ///</summary>
        public uint PagoxHorasExtras { get; set; }

        [NotMapped]
        public Hangar.Hangar Hangar { get; set; }
        /// <summary>
        /// Identificador del Hangar al que pertenece
        /// </summary>
        public int HangarId { get; set; }
        #endregion
        #region Methods
        ///<summary>
        ///Metodo que devueve el salario total a cobrar por el trabajador
        ///</summary>
        public uint Sueldo() { return (CantHorasTrabajadas * PagoxHoras) + (CantHorasExtras * PagoxHorasExtras); }
        #endregion
        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="AssuranceStaff"/>
        /// </summary>
        /// <param name="pagoXhoras">Pago por horas trabajadas</param>
        /// <param name="pagoXhorasextras">Pago por horas extras</param>
        /// <param name="nomb">Nombre</param>
        /// <param name="id">Numero de identificacion</param>
        /// <param name="cargo">Cargo que ocupa</param>

        public AssuranceStaff(uint pagoXhoras,uint pagoXhorasextras, string nomb, uint id, string cargo, Hangar.Hangar hangar) : base(nomb, id, cargo)
        {
            PagoxHoras = pagoXhoras;
            PagoxHorasExtras = pagoXhorasextras;
            CantHorasTrabajadas = 0;
            CantHorasExtras = 0;
            HangarId = hangar.Id;
        }

        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>

        protected AssuranceStaff () { }
        #endregion


    }
}
