using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MicroservicoCompras.Domain.Entities
{
    public class Pagamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


        public TipoPagamento Tipo { get; set; }

        public StatusPagamento Status { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; }
    }


    public enum TipoPagamento
    {
        CartaoCredito,
        Debito,
        Boleto,
        Pix
    }

    public enum StatusPagamento
    {
        Concluido,
        Pendente,
        NaoAceito
    }
}
