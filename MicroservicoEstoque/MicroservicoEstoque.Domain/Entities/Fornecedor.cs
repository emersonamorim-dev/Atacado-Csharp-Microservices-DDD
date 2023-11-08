using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class Fornecedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeFornecedor")]
        public string NomeFornecedor { get; set; }

        [BsonElement("Contato")]
        public ContatoFornecedor Contato { get; set; }

        [BsonElement("Endereco")]
        public string Endereco { get; set; }

        [BsonElement("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [BsonElement("StatusFornecedor")]
        public StatusFornecedor Status { get; set; }
    }

    public class ContatoFornecedor
    {
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Telefone")]
        public string Telefone { get; set; }
    }

    public enum StatusFornecedor
    {
        Ativo,
        Inativo,
        Pendente
    }
}
