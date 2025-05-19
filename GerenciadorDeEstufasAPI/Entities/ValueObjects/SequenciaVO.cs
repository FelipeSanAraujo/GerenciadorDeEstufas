namespace GerenciadorDeEstufas.Estufa.ValueObjects
{
    public class SequenciaVO
    {
        public SequenciaVO(int amostraInicial, int amostraFinal)
        {
            AmostraInicial = amostraInicial;
            AmostraFinal = amostraFinal;
        }

        public int AmostraInicial { get; set; }
        public int AmostraFinal { get; set; }
    }
}
