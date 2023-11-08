using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MicroservicoCompras.Domain.Entities
{
    public class Venda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public TipoProduto Produto { get; set; }

        [BsonRepresentation(BsonType.String)]
        public StatusVenda Status { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataVenda { get; set; }
    }

    public enum TipoProduto
    {
        Eletronico,
        Vestuario,
        Alimento,
        Livro

    }

    public enum StatusVenda
    {
        Concluida,
        EmProcessamento,
        Cancelada
    }
}
