namespace GerenciadorDeEstufasAPI.DTOs
{
    public class EstufaDTO
    {
        public Guid Id { get; set; }
        public int NumeroIdentificacao { get; set; }
        public int NumeroAmostrasPorFileira { get; set; }
        public int NumeroBandejas { get; set; }
        public IEnumerable<AmostraDTO>? AmostrasDTO { get; set; } = new List<AmostraDTO>();
    }
}
