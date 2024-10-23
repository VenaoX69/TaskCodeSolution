using TaskCode.Data;
using TaskCode.DTOs;
using TaskCode.Models;

namespace TaskCode.Commands
{
    public class CreateCategoriaCreditoCommandHandler
    {
        private readonly CarteraDbContext _context;

        public CreateCategoriaCreditoCommandHandler(CarteraDbContext context)
        {
            _context = context;
        }

        public async Task<CategriaCreditoDTO> Handle(CreateCategoriaCreditoCommand command)
        {
            var categoria = new CategoriaCredito
            {
                Categoria = command.Categoria,
                DiasDesde = command.DiasDesde,
                DiasHasta = command.DiasHasta,
                IsActive = true
            };

            _context.CategoriaCreditos.Add(categoria);
            await _context.SaveChangesAsync();

            return new CategriaCreditoDTO
            {
                Id = categoria.Id,
                Categoria = categoria.Categoria,
                DiasDesde = categoria.DiasDesde,
                DiasHasta = categoria.DiasHasta,
                IsActive = categoria.IsActive
            };
        }

    }
}
