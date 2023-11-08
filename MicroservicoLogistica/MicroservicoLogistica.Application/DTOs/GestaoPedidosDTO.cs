using System;
using System.Collections.Generic;

namespace MicroservicoLogistica.Application.DTOs
{
    public class GestaoPedidosDTO
    {
        public string Id { get; set; }
        public string NumeroPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public List<ItemPedidoDTO> ItensPedido { get; set; } = new List<ItemPedidoDTO>();
        public StatusPedidoDTO Status { get; set; }
        public DateTime DataEntregaEstimada { get; set; }
        public DateTime? DataEntregaReal { get; set; }
        public string EnderecoEntrega { get; set; }
        public string Observacoes { get; set; }
    }

    public class ItemPedidoDTO
    {
        public string ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }

    public enum StatusPedidoDTO
    {
        Recebido,
        EmProcessamento,
        Despachado,
        EmTransito,
        Entregue,
        Cancelado
    }
}
