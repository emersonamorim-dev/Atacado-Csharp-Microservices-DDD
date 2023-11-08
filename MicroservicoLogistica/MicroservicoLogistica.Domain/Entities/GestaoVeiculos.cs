using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoLogistica.Domain.Entities
{
    public class GestaoVeiculos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Modelo")]
        public string Modelo { get; set; }

        [BsonElement("AnoFabricacao")]
        public int AnoFabricacao { get; set; }

        [BsonElement("Placa")]
        public string Placa { get; set; }

        [BsonElement("Status")]
        public StatusVeiculo Status { get; set; }

        [BsonElement("DataUltimaManutencao")]
        public DateTime DataUltimaManutencao { get; set; }

        [BsonElement("Kilometragem")]
        public int Kilometragem { get; set; }
    }

    public enum StatusVeiculo
    {
        Disponivel,
        EmUso,
        EmManutencao,
        Inativo
    }
}
