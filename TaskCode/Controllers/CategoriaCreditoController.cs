using Microsoft.AspNetCore.Mvc;
using TaskCode.Commands;
using TaskCode.DTOs;
using TaskCode.Queries;

namespace TaskCode.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaCreditoController : ControllerBase
    {
        private readonly CreateCategoriaCreditoCommandHandler _createHandler;
        private readonly GetCategoriaCreditoQueryHandler _getHandler;

        public CategoriaCreditoController(CreateCategoriaCreditoCommandHandler createHandler, GetCategoriaCreditoQueryHandler getHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<ActionResult<CategriaCreditoDTO>> CreateCategCred(CreateCategoriaCreditoCommand command)
        {
            try 
            {
                var categoria = await _createHandler.Handle(command);
                return CreatedAtAction(nameof(GetCategoriaCredito), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear categoria: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategriaCreditoDTO?>> GetCategoriaCredito(int id)
        {
            var query = new GetCategoriaCreditoQuery { Id = id };
            var categoria = await _getHandler.Handle(query);

            if (categoria == null)
            {
                return NotFound("No se encontró la categoría.");
            }

            if (!categoria.IsActive)
            {
                return Ok(new { mensaje = "La categoría está desactivada.", categoria });
            }
            return Ok(categoria);
        }

    }
}
