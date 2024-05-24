using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BolestController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult VratiBolest(int id)
        {
            try
            {
                BolestBasic bolest = DataProvider.vratiBolest(id);
                return Ok(bolest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("sve")]
        public IActionResult VratiSveBolesti()
        {
            try
            {
                List<BolestPregled> bolesti = DataProvider.vratiSveBolesti();
                return Ok(bolesti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("dodaj")]
        public IActionResult DodajBolest(BolestBasic bolest)
        {
            try
            {
                DataProvider.dodajBolest(bolest);
                return Ok("Bolest uspešno dodata.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("izmeni")]
        public IActionResult IzmeniBolest(BolestBasic bolest)
        {
            try
            {
                DataProvider.izmeniBolest(bolest);
                return Ok("Bolest uspešno izmenjena.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiBolest(int id)
        {
            try
            {
                DataProvider.obrisiBolest(id);
                return Ok("Bolest uspešno obrisana.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
