using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;


        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _patientService.GetAllAsync());
        }
        [HttpGet]
        [Route("PatientData")]
        public async Task<IActionResult> GetCuredPatients()
        {
            return Ok(await _patientService.GetCuredPatients());
        }
        [HttpGet]
        [Route("PatientDataUncured")]
        public async Task<IActionResult> GetUnCuredPatients()
        {
            return Ok(await _patientService.GetUnCuredPatients());
        }
        [HttpGet]
        [Route("PatientDataFatility")]
        public async Task<IActionResult> GetFatilityCount()
        {
            return Ok(await _patientService.GetFatilityCount());
        }
        [HttpGet]
        [Route("PatientDataIsAffected")]
        public async Task<IActionResult> GetIsAffected()
        {
            return Ok(await _patientService.GetIsAffected());
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
    }
}