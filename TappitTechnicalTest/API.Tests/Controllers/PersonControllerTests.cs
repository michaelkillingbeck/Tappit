using API.Controllers;
using API.Interfaces.Services;
using API.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Tests.Controllers
{
    [TestClass]
    internal class PersonControllerTests
    {
        [TestMethod]
        public void GetAll_ShouldCallServiceOnceOnly()
        {
            var mockedService = new Mock<IPersonService>();
            mockedService.Setup(service => service.GetAllPeople()).Returns(new List<PersonSummaryDTO>());

            var controller = new PersonController(mockedService.Object);

            var result = controller.GetAll();

            mockedService.Verify(service => service.GetAllPeople(), Times.Once);
        }
    }
}
