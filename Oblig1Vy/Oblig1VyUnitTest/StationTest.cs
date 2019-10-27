using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using Oblig1Vy.Controllers;
using Oblig1Vy.BLL;
using Oblig1Vy.DAL;
using Oblig1Vy.DAL.Models;
using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;


namespace Oblig1VyUnitTest
{
    [TestClass]
    public class StationTest
    {
        [TestMethod]
        public void GetStations()
        {
            //Arrange
            var controller = new StationController(new StationService(new StationRepositoryStub()));

            var expected = new List<StationVm>();
            var Stations = new StationVm()
            {
                StationId = 0,
                StationName = "Stavanger",
            };
            expected.Add(Stations);
            expected.Add(Stations);
            expected.Add(Stations);

            // Act
            var actionResult = (ViewResult)controller.Index();
            var result = (List<StationVm>)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].StationId, result[i].StationId);
                Assert.AreEqual(expected[i].StationName, result[i].StationName);
            }

        }
        [TestMethod]
        public void Addstation()
        {
            //Arrange
            var controller = new StationController(new StationService(new StationRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.AddStation();

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

    }
}
