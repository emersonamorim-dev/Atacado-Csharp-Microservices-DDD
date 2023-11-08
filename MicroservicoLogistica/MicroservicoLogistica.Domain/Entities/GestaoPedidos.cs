using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoLogistica.Domain.Entities
{
    public class GestaoPedidos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NumeroPedido")]
        public string NumeroPedido { get; set; }

        [BsonElement("DataPedido")]
        public DateTime DataPedido { get; set; }

        [BsonElement("ItensPedido")]
        public List<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        [BsonElement("StatusPedido")]
        public StatusPedido Status { get; set; }

        [BsonElement("DataEntregaEstimada")]
        public DateTime DataEntregaEstimada { get; set; }

        [BsonElement("DataEntregaReal")]
        public DateTime? DataEntregaReal { get; set; }

        [BsonElement("EnderecoEntrega")]
        public string EnderecoEntrega { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public class ItemPedido
    {
        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [BsonElement("TotalItem")]
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }

    public enum StatusPedido
    {
        Recebido,
        EmProcessamento,
        Despachado,
        EmTransito,
        Entregue,
        Cancelado
    }
}
