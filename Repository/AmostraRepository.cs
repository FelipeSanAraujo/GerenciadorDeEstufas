using GerenciadorDeEstufas.Estufa;
using GerenciadorDeEstufasAPI.Context;
using GerenciadorDeEstufasAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEstufasAPI.Repository
{
    public class AmostraRepository : IAmostraRepository
    {
        private readonly GerenciadorContext _context;

        public AmostraRepository(GerenciadorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Amostra>> ConsultarAsync()
        {
            return await _context.Amostras.ToListAsync();
        }

        public async Task<Amostra> ConsultarPorIdAsync(int idAmostra)
        {
            return await _context.Amostras.FirstOrDefaultAsync(a => a.IdAmostra == idAmostra);
        }

        public async Task CriarAsync(Amostra amostra)
        {
            _context.Add(amostra);
            await _context.SaveChangesAsync();
        }

        public async Task CriarComListaAsync(List<Amostra> amostras)
        {
            _context.Amostras.AddRange(amostras);
            await _context.SaveChangesAsync();
        }
    }
}
