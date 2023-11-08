using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoLogistica.Domain.Entities
{
    public class GestaoRotas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Origem")]
        public string Origem { get; set; }

        [BsonElement("Destino")]
        public string Destino { get; set; }

        [BsonElement("VeiculoId")]
        public string VeiculoId { get; set; }

        [BsonElement("DataHoraPartida")]
        public DateTime DataHoraPartida { get; set; }

        [BsonElement("DataHoraChegadaPrevista")]
        public DateTime DataHoraChegadaPrevista { get; set; }

        [BsonElement("StatusRota")]
        public StatusRota Status { get; set; }

        [BsonElement("KilometragemPrevista")]
        public int KilometragemPrevista { get; set; }

        [BsonElement("KilometragemPercorrida")]
        public int KilometragemPercorrida { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public enum StatusRota
    {
        Planejada,
        EmAndamento,
        Concluida,
        Cancelada
    }
}
