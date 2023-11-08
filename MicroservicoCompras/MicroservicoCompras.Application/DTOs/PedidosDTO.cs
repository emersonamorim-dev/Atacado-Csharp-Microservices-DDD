using System;
using System.Collections.Generic;

namespace MicroservicoCompras.Application.DTOs
{
    public class PedidosDTO
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public List<ItemPedidosDTO> Itens { get; set; } = new List<ItemPedidosDTO>();
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
    }

    public class ItemPedidosDTO
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem { get; set; }

    }
}

