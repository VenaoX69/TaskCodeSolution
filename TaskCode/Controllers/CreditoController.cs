using Microsoft.AspNetCore.Mvc;
using TaskCode.Models;
using TaskCode.Services;

namespace TaskCode.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CreditoController : ControllerBase
    {
        private readonly CreditoService _creditoService;

        public CreditoController (CreditoService creditoService)
        {
            _creditoService = creditoService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaCredito>> CrearCategCred(CategoriaCredito categoria)
        {
            try
            {
                var created = await _creditoService.AddCred(categoria);
                if (created == null)
                {
                    return NotFound("Error en la creación.");
                }

                return created.Result!;
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al crear la categoria: {ex.Message}");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaCredito>> GetCatCred(int id)
        {
            var cred = await _creditoService.GetCategoriaCredito(id);
            if (cred == null)
            {
                return NotFound("No se encontro el id.");
            }
            return Ok(cred);
        }
    }
}
