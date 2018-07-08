using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTest
    {

        public AnalyticsControllerTest()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
        }
        private readonly AnalyticsController _analyticsController;
        private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();
        private readonly Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();

        [Fact]
        public async Task ShouldInsertAnalyticsData()
        {
            var oneHourElectricityModel = new OneHourElectricityModel()
            {
                DateTime = DateTime.UtcNow,
                KiloWatt = 1233
            };
            // Arrange

            // Act
            var result =await _analyticsController.Post("1", oneHourElectricityModel);
            
            //Assert
            Assert.NotNull(result);
            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        //[Fact]
        
        //public async Task GetCalls()
        //{

        //    // Arrange
        //    List<Panel> panlels = new List<Panel>();
        //    List<OneHourElectricity> oneHourElectricities = new List<OneHourElectricity>();

        //    //_panelRepositoryMock.Setup(repo => repo.Query())
        //    //    .Returns(panlels.AsQueryable());

        //    //_analyticsRepositoryMock.Setup(repo => repo.Query())
        //    //    .Returns(oneHourElectricities.AsQueryable());

        //    // Act
        //    var result = await _analyticsController.Get("1");

        //    //Assert
        //    Assert.NotNull(result);
        //    // Assert.
        //    //Assert.IsType<List<OneDayElectricityModel>>(result);
        //    Assert.IsType<OkResult>(result);
        //    //Assert.IsInstanceOf<List<OneHourElectricityListModel>> (variableName);
        //    // Assert.That(variableName, Is.InstanceOf<ClassName>());
        //}
        [Fact]
        public async Task DayResultsReturnsOneDayElectricityModelOK()
        {

            // Arrange
            
            
             // Act
             var result = await _analyticsController.DayResults("1");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);;
        }
    }
}
