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

        
        [HttpPost("dodajReceptAsync/{idFarmaceuta}/{idPakovanjaLeka}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddReceptAsync([FromBody] ReceptBasic rec, string idFarmaceuta, int idPakovanjaLeka)
        {
            (bool isError1, var farmaceut, var error1) = await DataProvider.vratiFarmaceutaAsync(idFarmaceuta);
            (bool isError2, var pakovanjeleka, var error2) = await DataProvider.vratiPakovanjeAsync(idPakovanjaLeka);
            (bool isError3, var prodajnomesto, var error3) = await DataProvider.vratiProdajnoMestoAsync(farmaceut.ProdajnoMesto.JedinstveniBroj);
            (bool isError4, var lek, var error4) = await DataProvider.vratiLekZaPakovanjeAsync(idPakovanjaLeka);

            if (isError1 || isError2 || isError3 || isError4)
            {
                return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}{Environment.NewLine}{error3?.Message}{Environment.NewLine}{error4?.Message}");
            }
            if (farmaceut == null || pakovanjeleka == null)
            {
                return BadRequest("Farmaceut ili pakovanje leka nije validno.");
            }

            var result = await DataProvider.dodajReceptAsync(rec, farmaceut, prodajnomesto, lek, pakovanjeleka);
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
            var result = DataProvider.IzmeniRecept(recept);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
