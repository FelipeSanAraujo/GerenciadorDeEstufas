using GerenciadorDeEstufas.Estufa;

namespace GerenciadorDeEstufasAPI.Repository.Interfaces
{
    public interface IEstufaRepository
    {
        Task CriarAsync(Estufa dto);
        Task AtualizarAsync(Estufa dto);
        Task<IEnumerable<Estufa>> ConsultarAsync();
        Task<Estufa> ConsultarComIdAsync(Guid id);
        Task<Estufa> ConsultarComIdAsyncEAmostras(Guid id);
    }
}
