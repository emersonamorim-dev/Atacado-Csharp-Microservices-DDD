using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Entities
{
    public class IntegracaoSistema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeSistema")]
        public string NomeSistema { get; set; }

        [BsonElement("TipoIntegracao")]
        public TipoIntegracao Tipo { get; set; }

        [BsonElement("Configuracao")]
        public ConfiguracaoIntegracao Configuracao { get; set; }

        [BsonElement("DataUltimaIntegracao")]
        public DateTime DataUltimaIntegracao { get; set; }

        [BsonElement("StatusIntegracao")]
        public StatusIntegracao Status { get; set; }
    }

    public class ConfiguracaoIntegracao
    {
        [BsonElement("URLAPI")]
        public string URLAPI { get; set; }

        [BsonElement("ChaveAPI")]
        public string ChaveAPI { get; set; }

        [BsonElement("Parametros")]
        public BsonDocument Parametros { get; set; }
    }

    public enum TipoIntegracao
    {
        API,
        BancoDados,
        Arquivo,
        Outros
    }

    public enum StatusIntegracao
    {
        Ativo,
        Inativo,
        Erro,
        Pendente
    }
}
