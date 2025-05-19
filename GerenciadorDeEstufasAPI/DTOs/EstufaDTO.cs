namespace GerenciadorDeEstufasAPI.DTOs
{
    public class EstufaDTO
    {
        public int NumeroIdentificacao { get; set; }
        public int NumeroAmostrasPorFileira { get; set; }
        public int NumeroBandejas { get; set; }
        public List<AmostraDTO>? AmostrasDTO { get; set; } = new List<AmostraDTO>();
    }
}
