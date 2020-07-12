using EpidemicTracker.Api.Controllers;
using EpidemicTracker.Api.Services;
using EpidemicTracker.data.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EpidemicTracker.Testcases
{
    public class PatientControllerTest
    {
        private readonly PatientController _patientController;
        private readonly EpidemicTrackerContext _dbContext;
        public PatientControllerTest()
        {
            _dbContext = DbContextMocker.InitializeDbContext();

            IPatientService patientService = new PatientService(_dbContext);
            _patientController = new PatientController(DbContextMocker.InitializeLogger(), patientService);
        }
        [Fact]
        public async Task TestGetStockItemsAsync()
        {
            //Arrange
            //Act
            var result = await _patientController.GetAllAsync() as ObjectResult;
            var value = result.Value as Patient;
            Assert.IsType<OkObjectResult>(value);

           
        }

        [Fact]
        public async Task getPatientIdTest()
        {
            // Arrange
            var testPatientId = 1;

            // Act
            var result = await _patientController.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            var patient = okObjectResult.Value as Patient;
            Assert.Equal(testPatientId, patient.PatientId);

        }
    }
}
