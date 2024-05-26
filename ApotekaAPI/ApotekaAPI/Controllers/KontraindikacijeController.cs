using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontraindikacijeController : ControllerBase
    {
        [HttpGet("vratiKontraindikacijeZaLek/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetKontraindikacijeZaLek(string id)
        {
            var result = DataProvider.vratiKontraindikacijeZaLek(id);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }

        
        [HttpPost("dodajKontraindikacijuAsync/{KomercijalniNazivLeka}/{idBolesti}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddKontraindikacijuAsync(string KomercijalniNazivLeka, int idBolesti)
        {
            (bool isError1, var lek, var error1) = await DataProvider.vratiLekAsync(KomercijalniNazivLeka);
            (bool isError2, var bolest, var error2) = await DataProvider.vratiBolestAsync(idBolesti);

            if (isError1 || isError2)
            {
            return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
            }
            if (lek == null || bolest == null)
            {
                return BadRequest("Lek ili bolest nije validna.");
            }

            var result = await DataProvider.dodajKontraindikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        
        [HttpDelete("obrisiKontrandikacijuAsync/{KomercijalniNazivLeka}/{idBolesti}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteKontraindikacijuAsync(string KomercijalniNazivLeka, int idBolesti)
        {
            (bool isError1, var lek, var error1) = await DataProvider.vratiLekAsync(KomercijalniNazivLeka);
            (bool isError2, var bolest, var error2) = await DataProvider.vratiBolestAsync(idBolesti);

            if (isError1 || isError2)
            {
            return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
            }
            if (lek == null || bolest == null)
            {
                return BadRequest("Lek ili bolest nije validna.");
            }

            var result = await DataProvider.obrisiKontrandikacijuAsync(lek, bolest);
            return result.IsError ? StatusCode(400, result.Error.Message) : Ok(result.Data);
        }
        

    }
}
