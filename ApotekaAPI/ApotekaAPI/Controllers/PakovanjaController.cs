using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PakovanjaController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult VratiPakovanjaZaLek(string id)
        {
            try
            {
                List<PakovanjaPregled> pakovanja = DataProvider.vratiPakovanjaZaLek(id);
                return Ok(pakovanja);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("dodaj")]
        public IActionResult DodajPakovanje([FromBody] PakovanjaBasic pakovanje)
        {
            try
            {
                DataProvider.dodajPakovanje(pakovanje);
                return Ok("Pakovanje uspešno dodano.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("vrati/{idPakovanja}")]
        public IActionResult VratiPakovanje(int idPakovanja)
        {
            try
            {
                PakovanjaBasic pak = DataProvider.vratiPakovanje(idPakovanja);
                return Ok(pak);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("izmeni")]
        public IActionResult IzmeniPakovanje([FromBody] PakovanjaBasic pakovanje)
        {
            try
            {
                DataProvider.IzmeniPakovanje(pakovanje);
                return Ok("Pakovanje uspešno izmenjeno.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("obrisi/{idPakovanja}")]
        public IActionResult ObrisiPakovanje(int idPakovanja)
        {
            try
            {
                DataProvider.obrisiPakovanje(idPakovanja);
                return Ok("Pakovanje uspešno obrisano.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
