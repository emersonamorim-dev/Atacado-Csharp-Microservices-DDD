using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Domain.Entities
{
    public class AutomacaoProcessos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [BsonElement("UsuarioId")]
        public string UsuarioId { get; set; }

        [BsonElement("NomeProcesso")]
        public string NomeProcesso { get; set; }

        [BsonElement("DescricaoProcesso")]
        public string DescricaoProcesso { get; set; }

        [BsonElement("PassosProcesso")]
        public List<PassoProcesso> PassosProcesso { get; set; } = new List<PassoProcesso>();

        [BsonElement("Status")]
        public StatusAutomacaoProcessos Status { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public class PassoProcesso
    {
        [BsonElement("Ordem")]
        public int Ordem { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("DataExecucao")]
        public DateTime? DataExecucao { get; set; }

        [BsonElement("Status")]
        public StatusPassoProcesso Status { get; set; }
    }

    public enum StatusAutomacaoProcessos
    {
        Pendente,
        EmExecucao,
        Concluido,
        Cancelado
    }

    public enum StatusPassoProcesso
    {
        Pendente,
        EmExecucao,
        Concluido,
        Cancelado,
        Erro
    }
}

