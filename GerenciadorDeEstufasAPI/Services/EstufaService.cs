using GerenciadorDeEstufas.Estufa;
using GerenciadorDeEstufasAPI.DTOs;
using GerenciadorDeEstufasAPI.Repository.Interfaces;
using GerenciadorDeEstufasAPI.Services.Interfaces;

namespace GerenciadorDeEstufasAPI.Services
{
    public class EstufaService : IEstufaService
    {
        private readonly IAmostraRepository _amostraRepository;
        private readonly IEstufaRepository _estufaRepository;

        public EstufaService(IAmostraRepository amostraRepository,
            IEstufaRepository estufaRepository)
        {
            _amostraRepository = amostraRepository;
            _estufaRepository = estufaRepository;
        }

        public async Task CriarAsync(EstufaDTO dto)
        {
            var estufa = new Estufa(dto.NumeroIdentificacao, 
                dto.NumeroAmostrasPorFileira,
                dto.NumeroBandejas);

            await _estufaRepository.CriarAsync(estufa);
        }

        public async Task AtualizarAsync(EstufaDTO dto, Guid id)
        {
            var estufa = await _estufaRepository.ConsultarComIdAsync(id);
            if(estufa is null)
            {
                throw new Exception("Nenhuma estufa cadastrada com o id informado.");
            }

            estufa.NumeroDeIdentificacao = dto.NumeroIdentificacao;
            estufa.NumeroDeAmostrasPorFileira = dto.NumeroAmostrasPorFileira;
            estufa.NumeroDeBandejas = dto.NumeroBandejas;

            await _estufaRepository.AtualizarAsync(estufa);
        }

        public async Task<IEnumerable<EstufaDTO>> ConsultarAsync()
        {
            var lista = await _estufaRepository.ConsultarAsync();
            var map = lista.Select(x => new EstufaDTO()
            {
                NumeroIdentificacao = x.NumeroDeIdentificacao,
                NumeroAmostrasPorFileira = x.NumeroDeAmostrasPorFileira,
                NumeroBandejas = x.NumeroDeBandejas
            });

            return map;
        }

        public async Task<EstufaDTO> ConsultarComIdAsync(Guid id)
        {
            var estufa = await _estufaRepository.ConsultarComIdAsync(id);
            return new EstufaDTO
            {
                NumeroIdentificacao = estufa.NumeroDeIdentificacao,
                NumeroAmostrasPorFileira = estufa.NumeroDeAmostrasPorFileira,
                NumeroBandejas = estufa.NumeroDeBandejas
            };
        }
    }
}
