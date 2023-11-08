using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class PrevisaoDemandaDTO
    {
        public string Id { get; set; }
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public List<VendaHistoricaDTO> HistoricoVendas { get; set; } = new List<VendaHistoricaDTO>();
        public int Previsao { get; set; }
        public DateTime DataPrevisao { get; set; }
    }

    public class VendaHistoricaDTO
    {
        public DateTime DataVenda { get; set; }
        public int QuantidadeVendida { get; set; }
    }
}






