using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Domain.Entities
{
    public class PlanejamentoFinanceiro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [BsonElement("UsuarioId")]
        public string UsuarioId { get; set; }

        [BsonElement("MetasFinanceiras")]
        public List<MetaFinanceira> MetasFinanceiras { get; set; } = new List<MetaFinanceira>();

        [BsonElement("DespesasPlanejadas")]
        public List<DespesaPlanejada> DespesasPlanejadas { get; set; } = new List<DespesaPlanejada>();

        [BsonElement("ReceitasEsperadas")]
        public decimal ReceitasEsperadas { get; set; }

        [BsonElement("TotalEconomizado")]
        public decimal TotalEconomizado { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public class MetaFinanceira
    {
        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        [BsonElement("DataPrevista")]
        public DateTime DataPrevista { get; set; }

        [BsonElement("Status")]
        public StatusMetaFinanceira Status { get; set; }
    }

    public class DespesaPlanejada
    {
        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        [BsonElement("DataPrevista")]
        public DateTime DataPrevista { get; set; }

        [BsonElement("Categoria")]
        public string Categoria { get; set; }
    }

    public enum StatusMetaFinanceira
    {
        Pendente,
        Alcancada,
        Cancelada
    }
}
