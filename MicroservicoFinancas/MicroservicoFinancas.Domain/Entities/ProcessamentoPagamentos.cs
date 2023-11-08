using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Domain.Entities
{
    public class ProcessamentoPagamentos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DataProcessamento")]
        public DateTime DataProcessamento { get; set; }

        [BsonElement("UsuarioId")]
        public string UsuarioId { get; set; }

        [BsonElement("Transacoes")]
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();

        [BsonElement("Status")]
        public StatusProcessamentoPagamentos Status { get; set; }

        [BsonElement("TotalProcessado")]
        public decimal TotalProcessado { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }
    }

    public class Transacao
    {
        [BsonElement("TransacaoId")]
        public string TransacaoId { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        [BsonElement("DataTransacao")]
        public DateTime DataTransacao { get; set; }

        [BsonElement("StatusTransacao")]
        public StatusTransacao StatusTransacao { get; set; }
    }

    public enum StatusProcessamentoPagamentos
    {
        Pendente,
        Processado,
        Erro
    }

    public enum StatusTransacao
    {
        Pendente,
        Concluida,
        Cancelada,
        Erro
    }
}
