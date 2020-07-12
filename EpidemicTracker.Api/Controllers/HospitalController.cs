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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;


        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _hospitalService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(int id)
        {
            return Ok(await _hospitalService.GetHospitalAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostHospitalAsync(HospitalDto hospitalDto)
        {
            await _hospitalService.PostHospitalAsync(hospitalDto);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalAsync(int id)
        {
            if (id < 0)
                return BadRequest("Not a valid Request");
            else
                await _hospitalService.DeleteHospitalAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospitalAsync(int id, HospitalDto hospitalDto)
        {
            await _hospitalService.UpdateHospitalAsync(id, hospitalDto);
            return Ok();
        }
    }
}