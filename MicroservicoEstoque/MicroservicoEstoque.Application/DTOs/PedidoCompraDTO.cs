using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class PedidoCompraDTO
    {
        public string Id { get; set; }
        public string FornecedorId { get; set; }
        public List<ItemPedidoCompraDTO> Itens { get; set; } = new List<ItemPedidoCompraDTO>();
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; } 
    }

    public class ItemPedidoCompraDTO
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem { get; set; } 
    }
}
