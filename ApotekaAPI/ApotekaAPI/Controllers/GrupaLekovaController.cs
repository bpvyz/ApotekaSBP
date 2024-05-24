using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApotekaLibrary;

namespace ApotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupaLekovaController : ControllerBase
    {
        [HttpGet]
        public IActionResult VratiSveGrupeLekova()
        {
            try
            {
                List<GrupaLekovaPregled> grupe = DataProvider.vratiSveGrupeLekova();
                return Ok(grupe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult VratiGrupuLekova(int id)
        {
            try
            {
                GrupaLekovaBasic grupa = DataProvider.vratiGrupuLekova(id);
                return Ok(grupa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
