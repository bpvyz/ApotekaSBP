using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaposleniController : ControllerBase
    {
        [HttpGet("svi")]
        public IActionResult VratiSveZaposlene()
        {
            try
            {
                List<ZaposleniPregled> zaposleni = DataProvider.vratiSveZaposlene();
                return Ok(zaposleni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("prodajno-mesto/{id}")]
        public IActionResult VratiZaposleneProdajnogMesta(string id)
        {
            try
            {
                List<ZaposleniPregled> zaposleni = DataProvider.vratiZaposleneProdajnogMesta(id);
                return Ok(zaposleni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult VratiZaposlenog(string id)
        {
            try
            {
                ZaposleniBasic zaposleni = DataProvider.vratiZaposlenog(id);
                return Ok(zaposleni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("dodaj/{prodajnomestoID}")]
        public IActionResult DodajZaposlenog([FromBody]ZaposleniBasic zaposleni, string prodajnomestoID)
        {
            var prodajnomesto = DataProvider.vratiProdajnoMesto(prodajnomestoID);
            try
            {
                DataProvider.dodajZaposlenog(zaposleni, prodajnomesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("izmeni")]
        public IActionResult IzmeniZaposlenog(ZaposleniBasic zaposleni)
        {
            try
            {
                DataProvider.izmeniZaposlenog(zaposleni);
                return Ok("Zaposleni uspešno izmenjen.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiZaposlenog(string id)
        {
            try
            {
                DataProvider.obrisiZaposlenog(id);
                return Ok("Zaposleni uspešno obrisan.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
