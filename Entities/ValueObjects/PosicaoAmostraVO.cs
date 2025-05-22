namespace GerenciadorDeEstufas.Estufa.ValueObjects
{
    public class PosicaoAmostraVO
    {
        public PosicaoAmostraVO()
        {
            Bandeja = 1;
            Fileira = 1;
            Posicao = 1;
        }

        public int Bandeja { get; set; }
        public int Fileira { get; set; }
        public int Posicao { get; set; }
    }
}
