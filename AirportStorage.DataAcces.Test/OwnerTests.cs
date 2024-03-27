using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Owners;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Owner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirportStorage.DataAcces.Tests
{
    /// <summary>
    /// Para ver si logro el merge
    /// </summary>
    public class OwnerTests
    {
        private IOwnerRepository _ownerRepository;


        public OwnerTests()
        {
            _ownerRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow("victor hugo",022123,3)]
        [DataRow("frank Sinatra", 029482, 4)]
        public void Can_Create_Owner(string nomb, uint id, uint cantjets)
        {
            //Arrange
            _ownerRepository.BeginTransaction();

            //Execute
            Owner newOwner = _ownerRepository.CreateOwner(nomb,id,cantjets);
            _ownerRepository.PartialCommit();  //generando id 
            Owner? loadedOwner = _ownerRepository.Get(newOwner.Id);
            _ownerRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedOwner);
            Assert.AreEqual(loadedOwner.CI, id);
            Assert.AreEqual(loadedOwner.Name, nomb);


        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Owner(int pos)
        {
            //Arrange 
            _ownerRepository.BeginTransaction();

            // Execute
            var loadedCompany = _ownerRepository.Get(pos);
            _ownerRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCompany);
        }

        [DataRow(1, "arthur conan doyle",62233,5)]
        [DataRow(2, "Brandon sanderson", 62233, 7)]
        [TestMethod]
        public void Can_Update_Company(int pos, string nomb, uint id, uint cantjets)
        {
            //Arrange
            _ownerRepository.BeginTransaction();

            //Execute
            var loadedOwner = _ownerRepository.Get(pos);
            Assert.IsNotNull(loadedOwner);
            var newOwner = new Owner(nomb,id,cantjets) { Id = loadedOwner.Id};
            _ownerRepository.Update(newOwner);
            var modifyedOwner = _ownerRepository.Get(pos);
            _ownerRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedOwner.Name, nomb);
           



        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Company(int id)
        {
            //Arrange
            _ownerRepository.BeginTransaction();

            //Execute
            var loadedOwner = _ownerRepository.Get(id);
            Assert.IsNotNull(loadedOwner);
            _ownerRepository.Delete(loadedOwner);
            _ownerRepository.PartialCommit();
            loadedOwner = _ownerRepository.Get(id);
            _ownerRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedOwner);



        }
    }
}
