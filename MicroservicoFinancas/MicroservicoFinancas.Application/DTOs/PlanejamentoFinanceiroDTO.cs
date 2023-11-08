using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Application.DTOs
{
    public class PlanejamentoFinanceiroDTO
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioId { get; set; }
        public List<MetaFinanceiraDTO> MetasFinanceiras { get; set; } = new List<MetaFinanceiraDTO>();
        public List<DespesaPlanejadaDTO> DespesasPlanejadas { get; set; } = new List<DespesaPlanejadaDTO>();
        public decimal ReceitasEsperadas { get; set; }
        public decimal TotalEconomizado { get; set; }
        public string Observacoes { get; set; }
    }

    public class MetaFinanceiraDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPrevista { get; set; }
        public StatusMetaFinanceiraDTO Status { get; set; }
    }

    public class DespesaPlanejadaDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPrevista { get; set; }
        public string Categoria { get; set; }
    }

    public enum StatusMetaFinanceiraDTO
    {
        Pendente,
        Alcancada,
        Cancelada
    }
}
