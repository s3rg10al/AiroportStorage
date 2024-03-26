using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Tests
{
    public class HangarTests
    {
        private IHangarRepository _hangarRepository;


        public HangarTests()
        {
            _hangarRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(200)]
        [DataRow(300)]
        [TestMethod]
        public void Can_Create_Hangar(int InitialCantMax )
        {
            //Arrange
            _hangarRepository.BeginTransaction();
            Company company = ((IcompanyRepository)_hangarRepository).Get(companyId);
            Assert.IsNotNull(company);

            //Execute
            Hangar newHangar = _hangarRepository.Create(InitialCantMax);
            _hangarRepository.PartialCommit();  //generando id 
            Hangar? loadedHangar = _hangarRepository.Get(newHangar.Id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHangar);
            Assert.AreEqual(loadedHangar.Currency, InitialCantMax);


        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Hangar(int id)
        {
            //Arrange 
            _hangarRepository.BeginTransaction();

            // Execute
            var loadedHangar = _hangarRepository.Get(id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHangar);
        }

        [DataRow(1, 200)]
        [DataRow(2, 300)]
        [TestMethod]
        public void Can_Update_Hangar(int id, int InitialCantMax)
        {
            //Arrange
            _hangarRepository.BeginTransaction();

            //Execute
            var loadedHangar = _hangarRepository.Get(id);
            Assert.IsNotNull(loadedHangar);
            var newHangar = new Hangar(InitialCantMax) { id = loadedHangar.Id };
            _hangarRepository.Update(newHangar);
            var modifyedHangar = _HangarRepository.Get(id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedHangar.Currency, InitialCantMax);



        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Hangar(int id)
        {
            //Arrange
            _hangarRepository.BeginTransaction();

            //Execute
            var loadedHangar = _hangarRepository.Get(id);
            Assert.IsNotNull(loadedHangar);
            _hangarRepository.Delete(loadedHangar);
            _hangarRepository.PartialCommit();
            loadedHangar = _hangarRepository.Get(id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedHangar);



        }
    }
}
