using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Application.DTOs
{
    public class ProcessamentoPagamentosDTO
    {
        public string Id { get; set; }
        public DateTime DataProcessamento { get; set; }
        public string UsuarioId { get; set; }
        public List<TransacaoDTO> Transacoes { get; set; } = new List<TransacaoDTO>();
        public StatusProcessamentoPagamentosDTO Status { get; set; }
        public decimal TotalProcessado { get; set; }
        public string Observacoes { get; set; }
    }

    public class TransacaoDTO
    {
        public string TransacaoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public StatusTransacaoDTO StatusTransacao { get; set; }
    }

    public enum StatusProcessamentoPagamentosDTO
    {
        Pendente,
        Processado,
        Erro
    }

    public enum StatusTransacaoDTO
    {
        Pendente,
        Concluida,
        Cancelada,
        Erro
    }
}
