using EpidemicTracker.Api.Controllers;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EpidemicTracker.Testcases
{
    public class HospitalServiceTest
    {
        HospitalController _controller;
        IHospitalService _service;
        public HospitalServiceTest()
        {
            _service = new HospitalServiceFake();
            _controller = new HospitalController(_service);
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
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = await _controller.GetAllAsync() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<HospitalDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
