using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ReceptController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptController : ControllerBase
    {
        [HttpGet("vratiRecepteProdajnogMestaAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRecepteProdajnogMestaAsync([FromBody] ProdajnoMestoBasic prodajnomesto)
        {
            var result = await DataProvider.vratiRecepteProdajnogMestaAsync(prodajnomesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiRecepteFarmaceutaAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRecepteFarmaceutaAsync([FromBody] FarmaceutBasic farmaceut)
        {
            var result = await DataProvider.vratiRecepteFarmaceutaAsync(farmaceut);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiRecept/{idRecepta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRecept(int idRecepta)
        {
            var result = await DataProvider.obrisiRecept(idRecepta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        /*
        [HttpPost("dodajReceptAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddReceptAsync([FromBody] ReceptBasic rec, [FromBody] FarmaceutBasic farmaceut, [FromBody] ProdajnoMestoBasic prodajnomesto, [FromBody] LekBasic lek, [FromBody] PakovanjaBasic pak)
        {
            var result = await DataProvider.dodajReceptAsync(rec, farmaceut, prodajnomesto, lek, pak);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        */

        [HttpGet("vratiReceptAsync/{idRecepta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReceptAsync(int idRecepta)
        {
            var result = await DataProvider.vratiReceptAsync(idRecepta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniRecept")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateRecept([FromBody] ReceptBasic recept)
        {
            var result = DataProvider.IzmeniRecept(recept);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
