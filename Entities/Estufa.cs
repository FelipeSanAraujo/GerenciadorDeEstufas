using GerenciadorDeEstufas.Estufa.ValueObjects;

namespace GerenciadorDeEstufas.Estufa
{
    public class Estufa
    {
        const int NUMERO_FILEIRAS = 3;

        public Estufa()
        {
        }
        public Estufa(int numeroDeIdentificacao
            , int numeroDeAmostrasPorFileira
            , int numeroDeBandejas)
        {
            Id = Guid.NewGuid();
            NumeroDeIdentificacao = numeroDeIdentificacao;
            NumeroDeAmostrasPorFileira = numeroDeAmostrasPorFileira;
            NumeroDeBandejas = numeroDeBandejas;
            Amostras = new List<Amostra>();
        }

        public Guid Id { get; private set; }
        public int NumeroDeIdentificacao { get; set; }
        public int NumeroDeAmostrasPorFileira { get; set; }
        public int NumeroDeBandejas { get; set; }
        public List<Amostra>? Amostras { get; set; } = new List<Amostra>();

        private PosicaoAmostraVO posicao = new();
        public void EncherEstufa(SequenciaVO sequencia)
        {
            for (int numeroAmostra = sequencia.AmostraInicial
                ; numeroAmostra <= sequencia.AmostraFinal
                ; numeroAmostra++)
            {
                var amostra = new Amostra(numeroAmostra
                    , posicao.Fileira
                    , posicao.Bandeja
                    , posicao.Posicao
                    , this.Id);

                Amostras.Add(amostra);
                posicao.Posicao++;

                if (posicao.Posicao > NumeroDeAmostrasPorFileira)
                {
                    posicao.Posicao = 1;
                    posicao.Fileira++;
                    if (posicao.Fileira > NUMERO_FILEIRAS)
                    {
                        posicao.Bandeja++;
                        posicao.Fileira = 1;
                        if(posicao.Bandeja > NumeroDeBandejas)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void EncherEstufa(List<SequenciaVO> sequencia)
        {
            foreach (var item in sequencia)
            {
                EncherEstufa(item);
            }
        }

        public Amostra EncontrarAmostra(int id)
        {
            return Amostras.Count != 0 ? Amostras
                .FirstOrDefault(a => a.Id == id) : throw new Exception("Sem amostras na estufa.");
        }
    }
}
