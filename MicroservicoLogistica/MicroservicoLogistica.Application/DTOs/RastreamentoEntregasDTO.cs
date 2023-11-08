using System;

namespace MicroservicoLogistica.Application.DTOs
{
    public class RastreamentoEntregasDTO
    {
        public string Id { get; set; }
        public string EntregaId { get; set; }
        public string LocalizacaoAtual { get; set; }
        public StatusEntregaDTO Status { get; set; }
        public DateTime DataHoraUltimaAtualizacao { get; set; }
        public string Observacoes { get; set; }
    }

    public enum StatusEntregaDTO
    {
        EmTransito,
        Entregue,
        Atrasado,
        Cancelado
    }
}
