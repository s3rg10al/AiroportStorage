using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportStorage.Domain.Entities.company;

namespace AirportStorage.DataAccess.Abstract.Companys
{
    public interface ICompanyRepository : IRepository
    {
        /// <summary>
        /// Crea una compagnia en BD
        /// <summary>
        /// constructor de la clase company que establece el pais donde se encuentraw
        /// </summary>
        /// <param name="InitialCountry">pais al que pertenece la compañia</param>
        Company Create(string InitialCountry);

        /// <summary>
        /// Obtiene una compagnia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Company? Get(int id);

        /// <summary>
        /// Actualiza los parametros de una compagnia en BD
        /// </summary>
        /// <param name="company"></param>
        void Update(Company company);

        /// <summary>
        /// Elima una compagnia de BD
        /// </summary>
        /// <param name="company"></param>
        void Delete(Company company);

    }
}