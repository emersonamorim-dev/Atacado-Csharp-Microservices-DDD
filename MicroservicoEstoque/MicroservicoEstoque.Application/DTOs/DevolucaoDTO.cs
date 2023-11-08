using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class DevolucaoDTO
    {
        public string Id { get; set; }
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public List<ItemDevolvidoDTO> ItensDevolvidos { get; set; } = new List<ItemDevolvidoDTO>();
        public string MotivoDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string StatusDevolucao { get; set; }
    }

    public class ItemDevolvidoDTO
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }
}