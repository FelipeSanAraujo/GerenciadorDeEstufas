namespace GerenciadorDeEstufasAPI.DTOs
{
    public struct EstufaDTO
    {
        public EstufaDTO(Guid id, int numeroIdentificacao, int numeroAmostrasPorFileira,
            int numeroBandejas)
        {
            Id = id;
            NumeroIdentificacao = numeroIdentificacao;
            NumeroAmostrasPorFileira = numeroAmostrasPorFileira;
            NumeroBandejas = numeroBandejas;
            Amostras = new List<AmostraDTO>();
        }

        public Guid Id { get; set; }
        public int NumeroIdentificacao { get; set; }
        public int NumeroAmostrasPorFileira { get; set; }
        public int NumeroBandejas { get; set; }
        public IEnumerable<AmostraDTO>? Amostras { get; set; }
    }
}
