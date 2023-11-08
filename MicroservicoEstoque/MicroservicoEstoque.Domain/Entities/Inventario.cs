using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class Inventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("QuantidadeEmEstoque")]
        public int QuantidadeEmEstoque { get; set; }

        [BsonElement("LocalizacaoArmazem")]
        public string LocalizacaoArmazem { get; set; }

        [BsonElement("DataUltimaAtualizacao")]
        public DateTime DataUltimaAtualizacao { get; set; }

        [BsonElement("StatusInventario")]
        public StatusInventario Status { get; set; }
    }

    public enum StatusInventario
    {
        Ativo,
        Inativo,
        Reabastecer
    }
}
