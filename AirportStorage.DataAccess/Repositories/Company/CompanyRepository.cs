using AirportStorage.DataAccess.Abstract.Companys;
using AirportStorage.Domain.Entities.company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace AirportStorage.DataAccess.Abstract.Company
namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : ICompanyRepository
    {
        public Company Create(string InitialCountry)
        {
            Company company = new Company(InitialCountry);
            _context.Add(company);
            return company;
        }


        Company? ICompanyRepository.GetCompany(int id)
        {
            return _context.Set<Company>().Find(id);
        }


        public void Update(Company company)
        {
            _context.Update(company);
        }


        public void Delete(Company company)
        {
            _context.Remove(company);
        }
    }
}
