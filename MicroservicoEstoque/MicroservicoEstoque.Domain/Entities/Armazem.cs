using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class Armazem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeArmazem")]
        public string NomeArmazem { get; set; }

        [BsonElement("Localizacao")]
        public string Localizacao { get; set; }

        [BsonElement("CapacidadeTotal")]
        public int CapacidadeTotal { get; set; }

        [BsonElement("EspacoOcupado")]
        public int EspacoOcupado { get; set; }

        [BsonElement("EspacoDisponivel")]
        public int EspacoDisponivel => CapacidadeTotal - EspacoOcupado;

        [BsonElement("ItensArmazenados")]
        public List<ItemArmazenado> ItensArmazenados { get; set; } = new List<ItemArmazenado>();

        [BsonElement("DataUltimaAtualizacao")]
        public DateTime DataUltimaAtualizacao { get; set; }

        [BsonElement("StatusArmazem")]
        public StatusArmazem Status { get; set; }
    }

    public class ItemArmazenado
    {
        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("LocalizacaoNoArmazem")]
        public string LocalizacaoNoArmazem { get; set; }
    }

    public enum StatusArmazem
    {
        Ativo,
        Inativo,
        EmManutencao
    }
}
