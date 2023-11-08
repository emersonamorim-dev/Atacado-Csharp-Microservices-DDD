using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoFinancas.Domain.Entities
{
    public class AnaliseFinanceira
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DataAnalise")]
        public DateTime DataAnalise { get; set; }

        [BsonElement("ClienteId")]
        public string ClienteId { get; set; }

        [BsonElement("RendaMensal")]
        public decimal RendaMensal { get; set; }

        [BsonElement("DespesasMensais")]
        public decimal DespesasMensais { get; set; }

        [BsonElement("ScoreCredito")]
        public int ScoreCredito { get; set; }

        [BsonElement("LimiteCreditoRecomendado")]
        public decimal LimiteCreditoRecomendado { get; set; }

        [BsonElement("Status")]
        public StatusAnaliseFinanceira Status { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public enum StatusAnaliseFinanceira
    {
        Aprovado,
        Reprovado,
        Pendente
    }
}
