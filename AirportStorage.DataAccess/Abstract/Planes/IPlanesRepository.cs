using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportStorage.Domain.Entities.Planes;

namespace AirportStorage.DataAccess.Abstract.Planes
{
    public interface  IPlanesRepository : IRepository
    {
        /// <summary>
        /// Crea un avion en BD
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="serialnumber"></param>
        /// <param name="cantkmsPM"></param>
        /// <returns></returns>
        Planes Create(string modelo, string serialnumber, uint cantkmsPM);

        /// <summary>
        /// Obtiene un avion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Planes? Get(int id);

        /// <summary>
        /// Actualiza los parametros de un avion en BD
        /// </summary>
        /// <param name="planes"></param>
        void Update(Planes planes);

        /// <summary>
        /// Elima un avion de BD
        /// </summary>
        /// <param name="planes"></param>
        void Delete(Planes planes);

    }
}
