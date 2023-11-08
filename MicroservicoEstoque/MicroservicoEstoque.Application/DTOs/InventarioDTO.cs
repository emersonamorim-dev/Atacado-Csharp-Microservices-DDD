using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class InventarioDTO
    {
        public string Id { get; set; }
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string LocalizacaoArmazem { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public string StatusInventario { get; set; } 
    }
}
