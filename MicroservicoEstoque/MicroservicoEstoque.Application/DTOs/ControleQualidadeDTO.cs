using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class ControleQualidadeDTO
    {
        public string Id { get; set; }
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataInspecao { get; set; }
        public string ResultadoInspecao { get; set; }
        public string Detalhes { get; set; }
        public string InspecaoPor { get; set; }
    }
}


