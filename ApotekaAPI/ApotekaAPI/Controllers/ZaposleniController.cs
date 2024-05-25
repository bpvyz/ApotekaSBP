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

        [HttpGet("vratiZaposleneProdajnogMesta/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetZaposleniProdajnogMesta(string id)
        {
            var result = DataProvider.vratiZaposleneProdajnogMesta(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        [HttpGet("vratiZaposlenog/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetZaposlenog(string id)
        {
            var result = await DataProvider.vratiZaposlenogAsync(id);
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

        [HttpDelete("obrisiZaposlenog/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteZaposlenog(string id)
        {
            var result = await DataProvider.obrisiZaposlenogAsync(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
    }
}
