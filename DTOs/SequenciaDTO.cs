using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEstufasAPI.DTOs
{
    public struct SequenciaDTO
    {
        public int AmostraInicial { get; set; }
        public int AmostraFinal { get; set; }
    }
}
