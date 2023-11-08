using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MicroservicoCompras.Domain.Entities
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nome { get; set; }


        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
