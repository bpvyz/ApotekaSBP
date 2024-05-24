using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LekController : ControllerBase
    {
        [HttpGet]
        public IActionResult VratiSveLekove()
        {
            try
            {
                List<LekPregled> lekovi = DataProvider.vratiSveLekove();
                return Ok(lekovi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("prodajnomesto/{id}")]
        public IActionResult VratiLekoveZaProdajnoMesto(string id)
        {
            try
            {
                ProdajnoMestoBasic pm = new ProdajnoMestoBasic() { JedinstveniBroj = id };
                List<LekPregled> lekovi = DataProvider.vratiLekoveZaProdajnoMesto(pm);
                return Ok(lekovi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult VratiLek(string id)
        {
            try
            {
                LekBasic lek = DataProvider.vratiLek(id);
                return Ok(lek);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("izmeni")]
        public IActionResult IzmeniLek(LekBasic lek)
        {
            try
            {
                DataProvider.IzmeniLek(lek);
                return Ok("Lek uspešno izmenjen.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiLek(string id)
        {
            try
            {
                DataProvider.obrisiLek(id);
                return Ok("Lek uspešno obrisan.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
