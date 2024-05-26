using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaceutController : ControllerBase
    {
        [HttpGet("vratiFarmaceutaAsync/{idFarmaceuta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFarmaceutaAsync(string idFarmaceuta)
        {
            var result = await DataProvider.vratiFarmaceutaAsync(idFarmaceuta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiFarmaceuteProdajnogMesta/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetFarmaceuteProdajnogMesta(string id)
        {
            var result = DataProvider.vratiFarmaceuteProdajnogMesta(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        
        [HttpPost("dodajFarmaceutaAsync/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddFarmaceutaAsync([FromBody] FarmaceutBasic farmaceut, string idProdajnogMesta)
        {
            (bool isError, var prodajnomesto, var error) = await DataProvider.vratiProdajnoMestoAsync(idProdajnogMesta);

            if (isError)
            {
                return StatusCode(error?.StatusCode ?? 400, $"{error?.Message}");
            }
            if (prodajnomesto == null)
            {
                return BadRequest("Prodavnica nije validna.");
            }
            
            var result = await DataProvider.dodajFarmaceutaAsync(farmaceut, prodajnomesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        

        [HttpPut("izmeniFarmaceuta")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateFarmaceuta([FromBody] FarmaceutBasic farmaceut)
        {
            var result = DataProvider.izmeniFarmaceuta(farmaceut);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiFarmaceuta/{idFarmaceuta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteFarmaceuta(string idFarmaceuta)
        {
            var result = await DataProvider.obrisiFarmaceuta(idFarmaceuta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
