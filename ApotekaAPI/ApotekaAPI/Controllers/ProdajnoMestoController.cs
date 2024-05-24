using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdajnoMestoController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSvaProdajnaMesta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSvaProdajnaMesta()
        {
            try
            {
                return new JsonResult(DataProvider.vratiSvaProdajnaMesta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiProdajnoMesto/{idProdajnogMesta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProdajnoMesto(string idProdajnogMesta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiProdajnoMesto(idProdajnogMesta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajProdajnoMesto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProdajnoMesto([FromBody] ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                DataProvider.dodajProdajnoMesto(prodajnomesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniProdajnoMesto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProdajnoMesto([FromBody] ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                DataProvider.izmeniProdajnoMesto(prodajnomesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiProdajnoMesto/{idProdajnogMesta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProdajnoMesto(string idProdajnogMesta)
        {
            try
            {
                DataProvider.obrisiProdajnoMesto(idProdajnogMesta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
