using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolestController : ControllerBase
    {
        [HttpGet("vratiBolestAsync/{idBolesti}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBolestAsync(int idBolesti)
        {
            var result = await DataProvider.vratiBolestAsync(idBolesti);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiSveBolestiAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllBolestiAsync()
        {
            var result = await DataProvider.vratiSveBolestiAsync();
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPost("dodajBolest")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddBolest([FromBody] BolestBasic bolest)
        {
            var result = DataProvider.dodajBolest(bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniBolest")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateBolest([FromBody] BolestBasic bolest)
        {
            var result = DataProvider.izmeniBolest(bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiBolestAsync/{idBolesti}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteBolestAsync(int idBolesti)
        {
            var result = await DataProvider.obrisiBolestAsync(idBolesti);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
