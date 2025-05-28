using GerenciadorDeEstufas.Estufa;
using GerenciadorDeEstufas.Estufa.ValueObjects;
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
                Id = x.Id,
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

        public async Task EncherEstufa(SequenciaDTO sequencia, int numeroEstufa)
        {
             var estufa = await _estufaRepository.ConsultarComIdentificacaoAsync(numeroEstufa);

            if (estufa is null)
                throw new Exception("Estufa não encontrada.");

             var sequenciaVO = new SequenciaVO(sequencia.AmostraInicial, sequencia.AmostraFinal);
             estufa.EncherEstufa(sequenciaVO);

             await _amostraRepository.CriarComListaAsync(estufa.Amostras);
        }

        public async Task EncherEstufa(List<SequenciaDTO> sequencia, int numeroEstufa)
        {
            var estufa = await _estufaRepository.ConsultarComIdentificacaoAsync(numeroEstufa);
            var sequenciasMap = new List<SequenciaVO>();

            if (estufa is null)
                throw new Exception("Estufa não encontrada.");

            foreach (var item in sequencia)
            {
                var sequenciaVo = new SequenciaVO(item.AmostraInicial, item.AmostraFinal);
                sequenciasMap.Add(sequenciaVo);
            }

            estufa.EncherEstufa(sequenciasMap);
            await _amostraRepository.CriarComListaAsync(estufa.Amostras);
        }

        public async Task<EstufaDTO> ConsultarComIdEAmostrasAsync(int numeroIdentificacao)
        {
            var estufa = await _estufaRepository
                .ConsultarComAmostrasPorIdentificacaoAsync(numeroIdentificacao);

            var dto = new EstufaDTO
            {
                NumeroIdentificacao = estufa.NumeroDeIdentificacao,
                NumeroAmostrasPorFileira = estufa.NumeroDeAmostrasPorFileira,
                NumeroBandejas = estufa.NumeroDeBandejas,
                Amostras = estufa.Amostras.Select(a => new AmostraDTO
                {
                    IdAmostra = a.IdAmostra,
                    NumeroBadeja = a.NumeroBadeja,
                    NumeroFileira = a.NumeroFileira,
                    Posicao = a.Posicao
                })
            };

            return dto;
        }
    }
}
