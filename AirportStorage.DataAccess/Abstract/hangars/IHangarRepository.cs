using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Hangar;

namespace AirportStorage.DataAccess.Abstract.hangars
{
    public interface IHangarRepository : IRepository
    {
        /// <summary>
        /// Crea un hangar en BD
        /// <summary>
        /// constructor de la clase Hangar 
        /// </summary>
        /// <param name="InitialCantMax">se debe iniciar la cantidad maxima de aviones</param>
        Hangar Create(int InitialCantMax, Company company); //pregunta tambien lleva el id de company

        /// <summary>
        /// Obtiene un hangar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Hangar? GetHangar(int id);
       
        
        
        /// <summary>
        /// Obtien todos los Workshop en base de datos
        /// </summary>
        /// <returns> Workshop en Base de Datos</returns>
        IEnumerable<Hangar> GetAllHangars();


        /// <summary>
        /// Actualiza los parametros de un hangar en BD
        /// </summary>
        /// <param name="Hangar"></param>
        void Update(Hangar hangars);

        /// <summary>
        /// Elima un hangar de BD
        /// </summary>
        /// <param name="Hangar"></param>
        void Delete(Hangar hangars);

    }
}