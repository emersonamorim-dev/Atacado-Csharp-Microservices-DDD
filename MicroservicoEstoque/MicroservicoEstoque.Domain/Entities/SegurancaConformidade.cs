using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class SegurancaConformidade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("DataVerificacao")]
        public DateTime DataVerificacao { get; set; }

        [BsonElement("Status")]
        public StatusConformidade Status { get; set; }

        [BsonElement("Detalhes")]
        public string Detalhes { get; set; }

        [BsonElement("Responsavel")]
        public string Responsavel { get; set; }
    }

    public enum StatusConformidade
    {
        Conforme,
        NãoConforme,
        EmRevisão,
        Pendente
    }
}
