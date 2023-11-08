using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoLogistica.Domain.Entities
{
    public class RastreamentoEntregas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("EntregaId")]
        public string EntregaId { get; set; }

        [BsonElement("LocalizacaoAtual")]
        public string LocalizacaoAtual { get; set; }

        [BsonElement("StatusEntrega")]
        public StatusEntrega Status { get; set; }

        [BsonElement("DataHoraUltimaAtualizacao")]
        public DateTime DataHoraUltimaAtualizacao { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public enum StatusEntrega
    {
        EmTransito,
        Entregue,
        Atrasado,
        Cancelado
    }
}
