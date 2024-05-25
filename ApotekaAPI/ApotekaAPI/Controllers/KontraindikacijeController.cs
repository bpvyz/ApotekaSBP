using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontraindikacijeController : ControllerBase
    {
        [HttpGet("vratiKontraindikacijeZaLek/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetKontraindikacijeZaLek(string id)
        {
            var result = DataProvider.vratiKontraindikacijeZaLek(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        /*
        [HttpPost("dodajKontraindikacijuAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddKontraindikacijuAsync([FromBody] LekBasic lek, [FromBody] BolestBasic bolest)
        {
            var result = await DataProvider.dodajKontraindikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        */

        /*
        [HttpDelete("obrisiKontrandikacijuAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteKontraindikacijuAsync([FromBody] LekBasic lek, [FromBody] BolestBasic bolest)
        {
            var result = await DataProvider.obrisiKontrandikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        */

    }
}
