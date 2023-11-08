using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MicroservicoCompras.Domain.Entities
{
    public class Pedidos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ClienteId { get; set; }

        public List<ItemPedidos> Itens { get; set; } = new List<ItemPedidos>();

        public decimal ValorTotal { get; set; }

        public DateTime DataPedido { get; set; }

        public StatusPedidos Status { get; set; }
    }

    public class ItemPedidos
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public decimal TotalItem { get; set; }

    }

    public enum StatusPedidos
    {
        EmProcessamento,
        Concluido,
        Cancelado
    }
}
