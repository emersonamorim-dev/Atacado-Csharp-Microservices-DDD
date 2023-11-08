using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class Relatorio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [BsonElement("TipoRelatorio")]
        public TipoRelatorio Tipo { get; set; }

        [BsonElement("Dados")]
        public BsonDocument Dados { get; set; }
    }

    public enum TipoRelatorio
    {
        Estoque,
        Fornecedores,
        Pedidos,
        Financeiro,
        Outros
    }
}
