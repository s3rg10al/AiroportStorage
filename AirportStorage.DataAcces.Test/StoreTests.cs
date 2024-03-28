using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Stores;
using AirportStorage.DataAccess.Abstract.Workshops;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AirportStorage.DataAcces.Tests
{
    [TestClass]
    public class StoreTests
    {
        private IStoreRepository _storeRepository;


        public StoreTests()
        {
            _storeRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(200,9.54, 2)]//como se pasa un date time?
        [DataRow(300, 9.14, 1)]
        [TestMethod]
        [Priority(3)]
        public void Can_Create_Store(uint cantPiezas, DateTime lastInv, int workshopsId)
        {
            //Arrange
            _storeRepository.BeginTransaction();
            Workshop workshop = ((IWorkshopRepository)_storeRepository).GetWorkshop(workshopsId);
            Assert.IsNotNull(workshop);

            //Execute
            Store store = (Store)_storeRepository.CreateStore(cantPiezas, lastInv, workshop);
            _storeRepository.PartialCommit();
            var loadedstore = _storeRepository.GetStore(store.Id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedstore);
            Assert.AreEqual(loadedstore.CantPiezas, store.CantPiezas );
            Assert.AreEqual(loadedstore.UltimoInv, store.UltimoInv );


        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        [Priority(4)]
        public void Can_Get_Store(int id)
        {
            //Arrange 
            _storeRepository.BeginTransaction();

            // Execute
            var loadedStore = _storeRepository.GetStore(id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedStore);
        }

        [DataRow(1,400, 2.54)]
        [DataRow(2,500,9.24)]
        [TestMethod]
        [Priority(4)]
        public void Can_Update_Store(int id, uint cantPiezas, DateTime lastInv)
        {
            //Arrange
            _storeRepository.BeginTransaction();
            var stores = _storeRepository.GetAllStore();
            Assert.IsNotNull(stores);
            Store store = stores.ElementAt(id);
            Assert.IsNotNull(store);


            //Execute
            store.CantPiezas = cantPiezas;
            store.UltimoInv = lastInv;
            _storeRepository.Update(store);
            _storeRepository.PartialCommit();

            //Assert
            Store updatedStore = _storeRepository.GetStore(store.Id);
            Assert.IsNotNull(updatedStore);
            Assert.AreEqual(updatedStore.CantPiezas, store.CantPiezas);
            Assert.AreEqual(updatedStore.UltimoInv, store.UltimoInv);

          
        }

        [DataRow(1)]
        [TestMethod]
        [Priority(6)]
        public void Can_Delete_Store(int id)
        {
            //Arrange
            _storeRepository.BeginTransaction();

            //Execute
            var loadedStore = _storeRepository.GetStore(id);
            Assert.IsNotNull(loadedStore);
            _storeRepository.Delete(loadedStore);
            _storeRepository.PartialCommit();
            loadedStore = _storeRepository.GetStore(id);
            _storeRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedStore);



        }
    }
}