using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Domain.Entities
{
    public class Riscos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("DataIdentificacao")]
        public DateTime DataIdentificacao { get; set; }

        [BsonElement("NivelRisco")]
        public NivelRisco NivelRisco { get; set; }

        [BsonElement("EstrategiaMitigacao")]
        public string EstrategiaMitigacao { get; set; }

        [BsonElement("Status")]
        public StatusRisco Status { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public enum NivelRisco
    {
        Baixo,
        Moderado,
        Alto,
        Critico
    }

    public enum StatusRisco
    {
        Identificado,
        Analisado,
        Mitigado,
        Monitorado,
        Encerrado
    }
}
