using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class PrevisaoDemanda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("HistoricoVendas")]
        public List<VendaHistorica> HistoricoVendas { get; set; } = new List<VendaHistorica>();

        [BsonElement("Previsao")]
        public int Previsao { get; set; }

        [BsonElement("DataPrevisao")]
        public DateTime DataPrevisao { get; set; }
    }

    public class VendaHistorica
    {
        [BsonElement("DataVenda")]
        public DateTime DataVenda { get; set; }

        [BsonElement("QuantidadeVendida")]
        public int QuantidadeVendida { get; set; }
    }
}
