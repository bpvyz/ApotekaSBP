using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PakovanjaController : ControllerBase
    {
        [HttpGet("vratiPakovanjaZaLek/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPakovanjaZaLek(string id)
        {
            var result = DataProvider.vratiPakovanjaZaLek(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPost("dodajPakovanje/{idLeka}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPakovanje([FromBody] PakovanjaBasic pakovanje, string idLeka)
        {
            (bool isError, var lek, var error) = await DataProvider.vratiLekAsync(idLeka);
            if (isError)
            {
            return StatusCode(error?.StatusCode ?? 400, $"{error?.Message}");
            }
            if (lek == null)
            {
                return BadRequest("Lek nije validan.");
            }
            var result = await DataProvider.dodajPakovanjeAsync(pakovanje, lek);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiPakovanjeAsync/{idPakovanja}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPakovanjeAsync(int idPakovanja)
        {
            var result = await DataProvider.vratiPakovanjeAsync(idPakovanja);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniPakovanje")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePakovanje([FromBody] PakovanjaBasic pakovanje)
        {
            var result = DataProvider.IzmeniPakovanje(pakovanje);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiPakovanjeAsync/{idPakovanja}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletePakovanjeAsync(int idPakovanja)
        {
            var result = await DataProvider.obrisiPakovanjeAsync(idPakovanja);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
