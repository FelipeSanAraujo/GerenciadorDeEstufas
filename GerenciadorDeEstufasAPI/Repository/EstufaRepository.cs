using GerenciadorDeEstufas.Estufa;
using GerenciadorDeEstufasAPI.Context;
using GerenciadorDeEstufasAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEstufasAPI.Repository
{
    public class EstufaRepository : IEstufaRepository
    {
        private readonly GerenciadorContext _context;

        public EstufaRepository(GerenciadorContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(Estufa estufa)
        {
            _context.Add(estufa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Estufa estufa)
        {
            _context.Update(estufa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Estufa>> ConsultarAsync()
        {
            return await _context.Estufas.ToListAsync();
        }

        public async Task<Estufa> ConsultarComIdAsync(Guid id)
        {
            return await _context.Estufas.Where(e => e.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        
        public async Task<Estufa> ConsultarComIdAsyncEAmostras(Guid id)
        {
            return await _context.Estufas.Where(e => e.Id.Equals(id))
                .Include(e => e.Amostras).FirstOrDefaultAsync();
        }
    }
}
