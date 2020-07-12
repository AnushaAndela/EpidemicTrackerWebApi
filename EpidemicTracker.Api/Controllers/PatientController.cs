using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EpidemicTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private ILogger<PatientController> logger;
        

        

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            this.logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _patientService.GetAllAsync());
        }
        [HttpGet]
        [Route("PatientData")]
        public IActionResult GetCuredPatients()
        {
            return Ok( _patientService.GetCuredPatients());
        }
        [HttpGet]
        [Route("PatientDataUncured")]
        public IActionResult GetUnCuredPatients()
        {
            return Ok( _patientService.GetUnCuredPatients());
        }
        [HttpGet]
        [Route("PatientDataFatility")]
        public IActionResult GetFatilityCount()
        {
            return Ok( _patientService.GetFatilityCount());
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(int id)
        {
            return Ok(await _patientService.GetPatientAsync(id));
        }



        [HttpPost]
        public async Task<IActionResult> PostPatientAsync(PatientDto patientdto)
        {
            await _patientService.PostPatientAsync(patientdto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAsync(int id)
        {
            if (id < 0)
                return BadRequest("Not a valid Request");
            else
            await _patientService.DeletePatientAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientAsync(int id,PatientDto patientdto)
        {
            await _patientService.UpdatePatientAsync(id,patientdto);
            return Ok();
        }

    }
}