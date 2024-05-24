using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KontraindikacijeController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult VratiKontraindikacijeZaLek(string id)
        {
            try
            {
                List<BolestPregled> kontraindikacije = DataProvider.vratiKontraindikacijeZaLek(id);
                return Ok(kontraindikacije);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("dodaj")]
        public IActionResult DodajKontraindikaciju([FromBody] DodajKontraindikacijuRequest request)
        {
            try
            {
                DataProvider.dodajKontraindikaciju(request.Lek, request.Bolest);
                return Ok("Kontraindikacija uspešno dodana.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("obrisi")]
        public IActionResult ObrisiKontraindikaciju([FromBody] ObrisiKontraindikacijuRequest request)
        {
            try
            {
                DataProvider.obrisiKontrandikaciju(request.Lek, request.Bolest);
                return Ok("Kontraindikacija uspešno obrisana.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    public class DodajKontraindikacijuRequest
    {
        public LekBasic Lek { get; set; }
        public BolestBasic Bolest { get; set; }
    }

    public class ObrisiKontraindikacijuRequest
    {
        public LekBasic Lek { get; set; }
        public BolestBasic Bolest { get; set; }
    }
}
