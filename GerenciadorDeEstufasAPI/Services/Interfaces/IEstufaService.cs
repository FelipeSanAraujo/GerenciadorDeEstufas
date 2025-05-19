using GerenciadorDeEstufasAPI.DTOs;

namespace GerenciadorDeEstufasAPI.Services.Interfaces
{
    public interface IEstufaService
    {
        Task CriarAsync(EstufaDTO estufa);
        Task AtualizarAsync(EstufaDTO estufa, Guid id);
        Task<IEnumerable<EstufaDTO>> ConsultarAsync();
        Task<EstufaDTO> ConsultarComIdAsync(Guid id);
    }
}
