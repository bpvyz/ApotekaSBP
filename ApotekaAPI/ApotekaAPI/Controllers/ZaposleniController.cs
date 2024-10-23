using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ZaposleniController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        [HttpGet("vratiSveZaposlene")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSviZaposleni()
        {
            var result = await DataProvider.vratiSveZaposleneAsync();
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiZaposleneProdajnogMesta/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetZaposleniProdajnogMesta(string idProdajnogMesta)
        {
            var result = DataProvider.vratiZaposleneProdajnogMesta(idProdajnogMesta);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiZaposlenog/{idZaposlenog}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetZaposlenog(string idZaposlenog)
        {
            var result = await DataProvider.vratiZaposlenogAsync(idZaposlenog);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPost("dodajZaposlenog/{idProdajnogMesta}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddZaposleni([FromBody] ZaposleniBasic zaposleni, string idProdajnogMesta)
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

            var result = await DataProvider.dodajZaposlenogAsync(zaposleni, prodajnomesto);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpPut("izmeniZaposlenog")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateZaposleni([FromBody] ZaposleniBasic zaposleni)
        {
            var result = DataProvider.izmeniZaposlenog(zaposleni);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpDelete("obrisiZaposlenog/{idZaposlenog}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteZaposlenog(string idZaposlenog)
        {
            var result = await DataProvider.obrisiZaposlenogAsync(idZaposlenog);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
