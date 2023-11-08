using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class IntegracaoSistemaDTO
    {
        public string Id { get; set; }
        public string NomeSistema { get; set; }
        public string TipoIntegracao { get; set; }
        public ConfiguracaoIntegracaoDTO Configuracao { get; set; }
        public DateTime DataUltimaIntegracao { get; set; }
        public string StatusIntegracao { get; set; }
    }

    public class ConfiguracaoIntegracaoDTO
    {
        public string URLAPI { get; set; }
        public string ChaveAPI { get; set; }
        public Dictionary<string, string> Parametros { get; set; } 
    }
}