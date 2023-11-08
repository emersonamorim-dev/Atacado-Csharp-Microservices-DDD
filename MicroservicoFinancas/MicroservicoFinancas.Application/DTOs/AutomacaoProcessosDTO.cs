using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Application.DTOs
{
    public class AutomacaoProcessosDTO
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioId { get; set; }
        public string NomeProcesso { get; set; }
        public string DescricaoProcesso { get; set; }
        public List<PassoProcessoDTO> PassosProcesso { get; set; } = new List<PassoProcessoDTO>();
        public StatusAutomacaoProcessosDTO Status { get; set; }
        public string Observacoes { get; set; }
    }

    public class PassoProcessoDTO
    {
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataExecucao { get; set; }
        public StatusPassoProcessoDTO Status { get; set; }
    }

    public enum StatusAutomacaoProcessosDTO
    {
        Pendente,
        EmExecucao,
        Concluido,
        Cancelado
    }

    public enum StatusPassoProcessoDTO
    {
        Pendente,
        EmExecucao,
        Concluido,
        Cancelado,
        Erro
    }
}
