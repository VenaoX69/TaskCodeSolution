using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskCode.Controllers;
using TaskCode.Data;
using TaskCode.Models;

namespace TaskCode.Services
{
    public class CreditoService
    {
        private readonly CarteraDbContext _carteraDb;

        public CreditoService(CarteraDbContext carteraDb)
        {
            _carteraDb = carteraDb;
        }

        public async Task<ActionResult<CategoriaCredito>> AddCred(CategoriaCredito categoria)
        {
            var exist = await _carteraDb.CategoriaCreditos.FirstOrDefaultAsync(c => c.Categoria == categoria.Categoria);

            if (exist != null)
            {
                return new ConflictObjectResult("La categoria ya existe");
            }

            _carteraDb.Add(categoria);
            await _carteraDb.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(CreditoController.GetCatCred), "Credito", new { id = categoria.Id }, categoria);
        }

        public async Task<ActionResult<CategoriaCredito>> GetCategoriaCredito(int id)
        {
            var categoria = await _carteraDb.CategoriaCreditos.FindAsync(id);
            return categoria!;
        }

    }
}
