using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Companys;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Tests
{
    public class CompanyTests
    {
        private ICompanyRepository _companyRepository;

        
        public CompanyTests()
        {
            _companyRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }
        
        [DataRow(cuba)]
        [DataRow(USA)]
        [TestMethod]
        public void Can_Create_Company(string InitialCountry)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            Company newCompany = _companyRepository.Create(InitialCountry);
            _companyRepository.PartialCommit();  //generando id 
            Company? loadedCompany = _companyRepository.Get(newCompany.Id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCompany);
            Assert.AreEqual(loadedCompany.Currency, InitialCountry);
            

        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Company(int id)
        {
            //Arrange 
            _companyRepository.BeginTransaction();

            // Execute
            var loadedCompany = _companyRepository.Get(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCompany);
        }

        [DataRow(1,cuba)]
        [DataRow(2, USA)]
        [TestMethod]
        public void Can_Update_Company(int id,string InitialCountry)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            var loadedCompany = _companyRepository.Get(id);
            Assert.IsNotNull(loadedCompany);
            var newCompany = new Company(InitialCountry) { id = loadedCompany.Id };
            _companyRepository.Update(newCompany);
            var modifyedCompany = _companyRepository.Get(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedCompany.Currency, InitialCountry);
          


        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Company(int id)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            var loadedCompany = _companyRepository.Get(id);
            Assert.IsNotNull(loadedCompany);
            _companyRepository.Delete(loadedCompany);
            _companyRepository.PartialCommit();
            loadedCompany = _companyRepository.Get(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedCompany);



        }
    }
}
