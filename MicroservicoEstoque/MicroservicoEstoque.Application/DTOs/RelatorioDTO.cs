using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class RelatorioDTO
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public TipoRelatorioDTO Tipo { get; set; }
        public Dictionary<string, object> Dados { get; set; } 
    }

    public enum TipoRelatorioDTO
    {
        Estoque,
        Fornecedores,
        Pedidos,
        Financeiro,
        Outros
    }
}