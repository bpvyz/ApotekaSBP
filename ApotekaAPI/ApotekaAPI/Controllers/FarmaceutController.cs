using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FarmaceutController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult VratiFarmaceuta(string id)
        {
            try
            {
                FarmaceutBasic farmaceut = DataProvider.vratiFarmaceuta(id);
                return Ok(farmaceut);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("prodajnomesto/{id}")]
        public IActionResult VratiFarmaceuteProdajnogMesta(string id)
        {
            try
            {
                List<FarmaceutPregled> farmaceuti = DataProvider.vratiFarmaceuteProdajnogMesta(id);
                return Ok(farmaceuti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut("izmeni")]
        public IActionResult IzmeniFarmaceuta(FarmaceutBasic farmaceut)
        {
            try
            {
                DataProvider.izmeniFarmaceuta(farmaceut);
                return Ok("Farmaceut uspešno izmenjen.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiFarmaceuta(string id)
        {
            try
            {
                DataProvider.obrisiFarmaceuta(id);
                return Ok("Farmaceut uspešno obrisan.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
