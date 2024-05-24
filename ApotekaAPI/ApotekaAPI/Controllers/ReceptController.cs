using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceptController : ControllerBase
    {
        [HttpGet("prodajnomesto")]
        public IActionResult VratiRecepteProdajnogMesta(ProdajnoMestoBasic prodajnoMesto)
        {
            try
            {
                List<ReceptPregled> recepti = DataProvider.vratiRecepteProdajnogMesta(prodajnoMesto);
                return Ok(recepti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("farmaceut")]
        public IActionResult VratiRecepteFarmaceuta(FarmaceutBasic farmaceut)
        {
            try
            {
                List<ReceptPregled> recepti = DataProvider.vratiRecepteFarmaceuta(farmaceut);
                return Ok(recepti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult VratiRecept(int id)
        {
            try
            {
                ReceptBasic recept = DataProvider.vratiRecept(id);
                return Ok(recept);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

        [HttpPut("izmeni")]
        public IActionResult IzmeniRecept(ReceptBasic recept)
        {
            try
            {
                DataProvider.IzmeniRecept(recept);
                return Ok("Recept uspešno izmenjen.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiRecept(int id)
        {
            try
            {
                DataProvider.obrisiRecept(id);
                return Ok("Recept uspešno obrisan.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
