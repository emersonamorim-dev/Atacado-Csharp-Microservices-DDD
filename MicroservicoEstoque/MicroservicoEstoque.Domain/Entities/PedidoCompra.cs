using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class PedidoCompra
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FornecedorId")]
        public string FornecedorId { get; set; }

        [BsonElement("Itens")]
        public List<ItemPedidoCompra> Itens { get; set; } = new List<ItemPedidoCompra>();

        [BsonElement("ValorTotal")]
        public decimal ValorTotal { get; set; }

        [BsonElement("DataPedido")]
        public DateTime DataPedido { get; set; }

        [BsonElement("Status")]
        public StatusPedidoCompra Status { get; set; }
    }

    public class ItemPedidoCompra
    {
        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [BsonElement("TotalItem")]
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }

    public enum StatusPedidoCompra
    {
        Pendente,
        Confirmado,
        Recebido,
        Cancelado
    }
}