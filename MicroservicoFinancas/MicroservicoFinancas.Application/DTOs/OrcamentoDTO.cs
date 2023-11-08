using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Application.DTOs
{
    public class OrcamentoDTO
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItemOrcamentoDTO> ItensOrcamento { get; set; } = new List<ItemOrcamentoDTO>();
        public decimal Total { get; set; }
        public StatusOrcamentoDTO Status { get; set; }
        public string ClienteId { get; set; }
        public string VendedorId { get; set; }
        public string Observacoes { get; set; }
    }

    public class ItemOrcamentoDTO
    {
        public string ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem { get; set; }
    }

    public enum StatusOrcamentoDTO
    {
        Pendente,
        Aprovado,
        Rejeitado
    }
}
