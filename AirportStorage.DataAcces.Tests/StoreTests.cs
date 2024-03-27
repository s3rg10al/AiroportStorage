using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Store;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Tests
{
    public class StoreTests
    {
        private IStoreRepository _storeRepository;


        public StoreTests()
        {
            _storeRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(200,9.54)]//como se pasa un date time?
        [DataRow(300, 9.14)]
        [TestMethod]
        public void Can_Create_Store(uint cantPiezas, DateTime lastInv,workshop)//falta ver si recibe workshop
        {
            //Arrange
            _storeRepository.BeginTransaction();

            //Execute
            Store newStore = _storeRepository.Create(cantPiezas,lastInv);
            _storeRepository.PartialCommit();  //generando id 
            Store? loadedStore = _storeRepository.Get(newStore.Id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedStore);
            Assert.AreEqual(loadedStore.CantPiezas, cantPiezas);
            Assert.AreEqual(loadedStore.UltimoInv, lastInv);


        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Store(int id)
        {
            //Arrange 
            _storeRepository.BeginTransaction();

            // Execute
            var loadedStore = _storeRepository.Get(id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedStore);
        }

        [DataRow(1,400, 2.54)]
        [DataRow(2,500,9.24)]
        [TestMethod]
        public void Can_Update_Store(int id, uint cantPiezas, DateTime lastInv, workshop)
        {
            //Arrange
            _storeRepository.BeginTransaction();

            //Execute
            var loadedStore = _storeRepository.Get(id);
            Assert.IsNotNull(loadedStore);
            var newStore = new Store(cantPiezas,lastInv,workshopId) { Id = loadedStore.Id };
            _storeRepository.Update(newStore);
            var modifyedStore = _storeRepository.Get(id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedStore.CantPiezas,cantPiezas);



        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Store(int id)
        {
            //Arrange
            _storeRepository.BeginTransaction();

            //Execute
            var loadedStore = _storeRepository.Get(id);
            Assert.IsNotNull(loadedStore);
            _storeRepository.Delete(loadedStore);
            _storeRepository.PartialCommit();
            loadedStore = _storeRepository.Get(id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedStore);



        }
    }
}