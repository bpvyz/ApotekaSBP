using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupaLekovaController : ControllerBase
    {
        [HttpGet("vratiSveGrupeLekovaAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllGrupaLekovaAsync()
        {
            var result = await DataProvider.vratiSveGrupeLekovaAsync();
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiGrupuLekovaAsync/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGrupaLekovaAsync(int id)
        {
            var result = await DataProvider.vratiGrupuLekovaAsync(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
