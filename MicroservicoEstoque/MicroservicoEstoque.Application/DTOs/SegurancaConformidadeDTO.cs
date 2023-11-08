using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class SegurancaConformidadeDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVerificacao { get; set; }
        public StatusConformidadeDTO Status { get; set; }
        public string Detalhes { get; set; }
        public string Responsavel { get; set; }
    }

    public enum StatusConformidadeDTO
    {
        Conforme,
        NaoConforme, 
        EmRevisao,  
        Pendente
    }
}