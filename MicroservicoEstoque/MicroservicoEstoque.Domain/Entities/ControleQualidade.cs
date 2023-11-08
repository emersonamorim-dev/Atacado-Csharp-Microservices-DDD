using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class ControleQualidade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("DataInspecao")]
        public DateTime DataInspecao { get; set; }

        [BsonElement("ResultadoInspecao")]
        public ResultadoInspecao Resultado { get; set; }

        [BsonElement("Detalhes")]
        public string Detalhes { get; set; }

        [BsonElement("InspecaoPor")]
        public string InspecaoPor { get; set; }
    }

    public enum ResultadoInspecao
    {
        Aprovado,
        Reprovado,
        Pendente
    }
}
