using TaskCode.Data;
using TaskCode.DTOs;
using TaskCode.Models;

namespace TaskCode.Queries
{
    public class GetCategoriaCreditoQueryHandler
    {
        private readonly CarteraDbContext _context;

        public GetCategoriaCreditoQueryHandler(CarteraDbContext context)
        {
            _context = context;
        }

        public async Task<CategriaCreditoDTO?> Handle(GetCategoriaCreditoQuery query)
        {
            var categoria = await _context.CategoriaCreditos.FindAsync(query.Id);
            if (categoria == null)
            {
                return null;
            }

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
