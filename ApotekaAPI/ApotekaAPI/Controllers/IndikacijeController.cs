using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndikacijeController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult VratiIndikacijeZaLek(string id)
        {
            try
            {
                List<BolestPregled> indikacije = DataProvider.vratiIndikacijeZaLek(id);
                return Ok(indikacije);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("dodaj")]
        public IActionResult DodajIndikaciju([FromBody] DodajIndikacijuRequest request)
        {
            try
            {
                DataProvider.dodajIndikaciju(request.Lek, request.Bolest);
                return Ok("Indikacija uspešno dodana.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("obrisi")]
        public IActionResult ObrisiIndikaciju([FromBody] ObrisiIndikacijuRequest request)
        {
            try
            {
                DataProvider.obrisiIndikaciju(request.Lek, request.Bolest);
                return Ok("Indikacija uspešno obrisana.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    public class DodajIndikacijuRequest
    {
        public LekBasic Lek { get; set; }
        public BolestBasic Bolest { get; set; }
    }

    public class ObrisiIndikacijuRequest
    {
        public LekBasic Lek { get; set; }
        public BolestBasic Bolest { get; set; }
    }
}
