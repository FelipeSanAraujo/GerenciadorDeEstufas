using GerenciadorDeEstufas.Estufa;

namespace GerenciadorDeEstufasAPI.Repository.Interfaces
{
    public interface IAmostraRepository
    {
        Task CriarAsync(Amostra amostra);
        Task CriarComListaAsync(List<Amostra> amostras);
        Task<IEnumerable<Amostra>> ConsultarAsync();
        Task<Amostra> ConsultarPorIdAsync(int id);
    }
}
