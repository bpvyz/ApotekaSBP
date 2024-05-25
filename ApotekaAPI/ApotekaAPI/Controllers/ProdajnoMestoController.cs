using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdajnoMestoController : ControllerBase
    {
        [HttpGet("vratiSvaProdajnaMesta")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetSvaProdajnaMesta()
        {
            var result = DataProvider.vratiSvaProdajnaMesta();
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiProdajnoMestoAsync/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProdajnoMestoAsync(string idProdajnogMesta)
        {
            var result = await DataProvider.vratiProdajnoMestoAsync(idProdajnogMesta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPost("dodajProdajnoMestoAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProdajnoMestoAsync([FromBody] ProdajnoMestoBasic prodajnoMesto)
        {
            var result = await DataProvider.dodajProdajnoMestoAsync(prodajnoMesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniProdajnoMesto")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateProdajnoMesto([FromBody] ProdajnoMestoBasic prodajnoMesto)
        {
            var result = await DataProvider.izmeniProdajnoMesto(prodajnoMesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiProdajnoMestoAsync/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteProdajnoMestoAsync(string idProdajnogMesta)
        {
            var result = await DataProvider.obrisiProdajnoMestoAsync(idProdajnogMesta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
