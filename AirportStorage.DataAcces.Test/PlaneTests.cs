using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Plane;
using AirportStorage.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Test
{
    [TestClass]
    internal class PlaneTests
    {
        private IPlanesRepository _planesReposityory;

        public PlaneTests()
        {
            _planesReposityory = new ApliccationRepository(ConnectionStringProvider.GetConnectionString()); 
        }



        [TestMethod]
        [DataRow()]

        public 
        //Arrange 
        _planeRepository




    }
}
