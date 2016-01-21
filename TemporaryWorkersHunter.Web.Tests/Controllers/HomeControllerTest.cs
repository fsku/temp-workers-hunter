using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Service;
using TemporaryWorkersHunter.Web.Controllers;

namespace TemporaryWorkersHunter.Web.Tests.Controllers
{
    [TestClass]
    public class WorkerControllerTest
    {
        private Mock<IWorkerService> _workerServiceMock;
        WorkersController objController;
        List<Worker> listWorkers;

        [TestInitialize]
        public void Initialize()
        {

            _workerServiceMock = new Mock<IWorkerService>();
            objController = new WorkersController(_workerServiceMock.Object);
            listWorkers = new List<Worker>() {
             new Worker()
             {
                 FirstName = "Filip",
                 LastName = "Skurniak",
             }
            };
        }

        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _workerServiceMock.Setup(x => x.GetAll()).Returns(listWorkers);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Worker>;

            //Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual("Filip", result[0].FirstName);
            Assert.AreEqual("Skurniak", result[0].LastName);
        }
    }
}
