using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class Devolucao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PedidoId")]
        public string PedidoId { get; set; }

        [BsonElement("ClienteId")]
        public string ClienteId { get; set; }

        [BsonElement("ItensDevolvidos")]
        public List<ItemDevolvido> ItensDevolvidos { get; set; } = new List<ItemDevolvido>();

        [BsonElement("MotivoDevolucao")]
        public string MotivoDevolucao { get; set; }

        [BsonElement("DataDevolucao")]
        public DateTime DataDevolucao { get; set; }

        [BsonElement("StatusDevolucao")]
        public StatusDevolucao Status { get; set; }
    }

    public class ItemDevolvido
    {
        [BsonElement("ProdutoId")]
        public string ProdutoId { get; set; }

        [BsonElement("NomeProduto")]
        public string NomeProduto { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [BsonElement("TotalItem")]
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }

    public enum StatusDevolucao
    {
        Pendente,
        Confirmado,
        Processando,
        Concluido,
        Recusado
    }
}
