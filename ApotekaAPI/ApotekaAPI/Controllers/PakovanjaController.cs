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

        [HttpPost("dodajPakovanje")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPakovanje([FromBody] PakovanjaBasic pakovanje)
        {
            var result = await DataProvider.dodajPakovanje(pakovanje);
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
