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
        [HttpGet("vratiRecepteProdajnogMestaAsync/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRecepteProdajnogMestaAsync(string idProdajnogMesta)
        {
	    (bool isError, var prodajnomesto, var error) = await DataProvider.vratiProdajnoMestoAsync(idProdajnogMesta);
            
            if (isError)
            {
                return StatusCode(error?.StatusCode ?? 400, $"{error?.Message}");
            }
            if (prodajnomesto == null)
            {
                return BadRequest("Prodajno mesto nije validno.");
            }

            var result = await DataProvider.vratiRecepteProdajnogMestaAsync(prodajnomesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiRecepteFarmaceutaAsync/{idFarmaceuta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRecepteFarmaceutaAsync(string idFarmaceuta)
        {
	    (bool isError, var farmaceut, var error) = await DataProvider.vratiFarmaceutaAsync(idFarmaceuta);
            
            if (isError)
            {
                return StatusCode(error?.StatusCode ?? 400, $"{error?.Message}");
            }
            if (farmaceut == null)
            {
                return BadRequest("Farmaceut nije validan.");
            }
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

        
        [HttpPost("dodajReceptAsync/{idFarmaceuta}/{idPakovanjaLeka}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddReceptAsync([FromBody] ReceptBasic rec, string idFarmaceuta, int idPakovanjaLeka)
        {
            (bool isError1, var farmaceut, var error1) = await DataProvider.vratiFarmaceutaAsync(idFarmaceuta);
            (bool isError2, var pakovanjeleka, var error2) = await DataProvider.vratiPakovanjeAsync(idPakovanjaLeka);

            if (isError1 || isError2)
            {
                return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
            }
            if (farmaceut == null || pakovanjeleka == null)
            {
                return BadRequest("Farmaceut ili pakovanje leka nije validno.");
            }

            var result = await DataProvider.dodajReceptAsync(rec, farmaceut, pakovanjeleka);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        

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
            if (recept == null || recept.SerijskiBroj <= 0)
            {
                return BadRequest("Invalid input.");
            }
            var result = DataProvider.IzmeniRecept(recept);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
