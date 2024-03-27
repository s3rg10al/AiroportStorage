using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Workshops;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestClass]
public class WorkshopTest
{
    private IWorkshopRepository _WorkshopRepository;
    public WorkshopTest()
    {
        _WorkshopRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString())
        }
    [DataRow(10, store, company)]
    [TestMethod]
    public void Can_Create_Workshop(uint ability, Store store, Company company)
    {
        //Arrage
        _WorkshopRepository.BeginTransaction();

        //Execute
        Workshop newWorkshop = _WorkshopRepository.Create(ability, store, company);
        _WorkshopRepository.PartialCommit();//Generando id del nuevo elemento.
        Workshop? loadedWorkshop = _WorkshopRepository.Get(newWorkshop.Id);
        _WorkshopRepository.CommitTransaction();

        // Assert
        Assert.IsNotNull(loadedWorkshop);
        Assert.AreEqual(loadedWorkshop.Ability, ability);
        Assert.AreEqual(loadedWorkshop.Store, store);
        Assert.AreEqual(loadedWorkshop.company, company);
    }
    [DataRow(1)]
    [TestMethod]
    public void Can_Get_Workshop(int id)
    {
        //Arrage
        _WorkshopRepository.BeginTransaction();

        //Execute
        var loadedWorkshop = _WorkshopRepository.Get(id);
        _WorkshopRepository.CommitTransaction();

        //Assert
        Assert.IsNotNull(loadedWorkshop);
    }
    [DataRow(10, store, company)]
    [TestMethod]
    public void Can_Update_Workshop(int id, uint ability, Store store, Company company)
    {
        //Arrange
        _WorkshopRepository.BeginTransaction();

        //Execute
        var loadWorkshop = _WorkshopRepository.Get(id);
        Assert.IsNotNull(loadWorkshop);
        var newWorkshop = new Workshop(ability, store, company) { Id = loadWorkshop.Id };
        _WorkshopRepository.Update(newWorkshop);
        var modifyedWorkshop = _WorkshopRepository.Get(id);
        _WorkshopRepository.CommitTransaction();

        //Assert
        Assert.AreEqual(modifyedWorkshop.Ability, ability);
        Assert.AreEqual(modifyedWorkshop.Store, store);
        Assert.AreEqual(modifyedWorkshop.company, company);
    }
    [DataRow(1)]
    [TestMethod]
    public void Can_Delete_Workshop(int id)
    {
        //Arrange
        _WorkshopRepository.BeginTransaction();

        //Execute
        var loadedWorkshop = _WorkshopRepository.Get(id);
        Assert.IsNotNull(loadedWorkshop);
        _WorkshopRepository.Delete(loadedWorkshop);
        _WorkshopRepository.PartialCommit();
        loadedWorkshop = _WorkshopRepository.Get(id);
        _WorkshopRepository.CommitTransaction();

        //Assert
        Assert.IsNull(loadedWorkshop);
    }
}
