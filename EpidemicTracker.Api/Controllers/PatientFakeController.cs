using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFakeController : ControllerBase
    {
        private readonly IPatientServiceFake _patientServiceFake;

        public PatientFakeController(IPatientServiceFake patientServiceFake)
        {

            _patientServiceFake = patientServiceFake;
        }
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            return Ok( _patientServiceFake.GetAllItems());
        }
        [HttpGet("{id}")]
        public IActionResult GetPatientAsync(int id)
        {
            return Ok(_patientServiceFake.GetById(id));
        }



        [HttpPost]
        public IActionResult PostPatientAsync(Patient patient)
        {
             _patientServiceFake.Add(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatientAsync(int id)
        {
            if (id < 0)
                return BadRequest("Not a valid Request");
            else
               _patientServiceFake.Remove(id);
            return Ok();
        }
    }
}