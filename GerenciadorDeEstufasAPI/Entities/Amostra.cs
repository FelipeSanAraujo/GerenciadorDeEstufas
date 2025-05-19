namespace GerenciadorDeEstufas.Estufa
{
    public class Amostra
    {
        public Amostra()
        {
        }

        public Amostra(int id, int numeroFileira
            , int numeroBadeja, int posicao, Guid estufaId)
        {
            Id = id;
            NumeroFileira = numeroFileira;
            NumeroBadeja = numeroBadeja;
            Posicao = posicao;
            EstufaId = estufaId;
        }

        public int Id { get; private set; }
        public int NumeroFileira { get; private set; }
        public int NumeroBadeja { get; private set; }
        public int Posicao { get; private set; }
        public Guid EstufaId { get; private set; }
    }
}
