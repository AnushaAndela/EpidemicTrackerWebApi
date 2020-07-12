using EpidemicTracker.Api.Controllers;
using EpidemicTracker.Api.Services;
using EpidemicTracker.data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EpidemicTracker.Testcases
{
    public class PatientServiceTest
    {
        PatientFakeController _controller;
        IPatientServiceFake _service;
        public PatientServiceTest()
        {
            _service = new PatientServiceFake();
            _controller = new PatientFakeController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAllAsync() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Patient>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }
        //GetById
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetPatientAsync(3 );

            // Assertid
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
         

            // Act
            var okResult = _controller.GetPatientAsync(2);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            

            // Act
            var okResult = _controller.GetPatientAsync(1) as OkObjectResult;

            // Assert
            Assert.IsType<Patient>(okResult.Value);
            Assert.Equal(2, (okResult.Value as Patient).PatientId);
        }

    }
}
