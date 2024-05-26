using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekController : ControllerBase
    {
        [HttpGet("vratiSveLekove")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSviLekovi()
        {
            var result = await DataProvider.vratiSveLekove();
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiLekoveZaProdajnoMesto")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetLekoviZaProdajnoMesto([FromBody] ProdajnoMestoBasic pm)
        {
            var result = DataProvider.vratiLekoveZaProdajnoMesto(pm);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        
        [HttpPost("dodajLek/{idProdajnogMesta}/{idGrupeLekova}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddLek([FromBody] LekBasic lek, int idGrupeLekova, string idProdajnogMesta)
        {
            (bool isError1, var prodajnomesto, var error1) = await DataProvider.vratiProdajnoMestoAsync(idProdajnogMesta);
            (bool isError2, var grupalekova, var error2) = await DataProvider.vratiGrupuLekovaAsync(idGrupeLekova);

            if (isError1 || isError2)
            {
            return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
            }
            if (prodajnomesto == null || grupalekova == null)
            {
                return BadRequest("Prodajno mesto ili grupa lekova nije validna.");
            }

            var result = await DataProvider.dodajLekAsync(lek, grupalekova, prodajnomesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiLekAsync/{idLeka}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLekAsync(string idLeka)
        {
            var result = await DataProvider.vratiLekAsync(idLeka);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniLek")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateLek([FromBody] LekBasic lek)
        {
            var result = DataProvider.IzmeniLek(lek);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiLekAsync/{idLeka}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteLekAsync(string idLeka)
        {
            var result = await DataProvider.obrisiLekAsync(idLeka);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
