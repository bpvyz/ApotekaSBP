using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndikacijeController : ControllerBase
    {
        [HttpGet("vratiIndikacijeZaLek/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetIndikacijeZaLek(string id)
        {
            var result = DataProvider.vratiIndikacijeZaLek(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        
        /*
        [HttpPost("dodajIndikacijuAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddIndikacijuAsync([FromBody] LekBasic lek, [FromBody] BolestBasic bolest)
        {
            var result = await DataProvider.dodajIndikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        */

        /*
        [HttpDelete("obrisiIndikacijuAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteIndikacijuAsync([FromBody] LekBasic lek, [FromBody] BolestBasic bolest)
        {
            var result = await DataProvider.obrisiIndikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        */

    }
}
