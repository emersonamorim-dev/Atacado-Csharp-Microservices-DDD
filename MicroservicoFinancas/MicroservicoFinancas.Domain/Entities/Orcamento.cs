using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoFinancas.Domain.Entities
{
    public class Orcamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [BsonElement("ItensOrcamento")]
        public List<ItemOrcamento> ItensOrcamento { get; set; } = new List<ItemOrcamento>();

        [BsonElement("Total")]
        public decimal Total => ItensOrcamento.Sum(item => item.TotalItem);

        [BsonElement("StatusOrcamento")]
        public StatusOrcamento Status { get; set; }

        [BsonElement("ClienteId")]
        public string ClienteId { get; set; }

        [BsonElement("VendedorId")]
        public string VendedorId { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public class ItemOrcamento
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

    public enum StatusOrcamento
    {
        Pendente,
        Aprovado,
        Rejeitado
    }
}
