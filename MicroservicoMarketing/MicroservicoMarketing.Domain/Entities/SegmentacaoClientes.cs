using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicoMarketing.Domain.Entities
{
    public class SegmentacaoClientes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeSegmento")]
        public string NomeSegmento { get; set; }

        [BsonElement("Critérios")]
        public string Critérios { get; set; } 

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [BsonElement("Clientes")]
        public List<string> ClientesIds { get; set; } 

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        public SegmentacaoClientes()
        {
            ClientesIds = new List<string>();
        }
    }
}
