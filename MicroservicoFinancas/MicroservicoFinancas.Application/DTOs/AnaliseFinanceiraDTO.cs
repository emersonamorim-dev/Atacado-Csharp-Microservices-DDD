using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.DTOs
{
    public class AnaliseFinanceiraDTO
    {
        public string Id { get; set; }
        public DateTime DataAnalise { get; set; }
        public string ClienteId { get; set; }
        public decimal RendaMensal { get; set; }
        public decimal DespesasMensais { get; set; }
        public int ScoreCredito { get; set; }
        public decimal LimiteCreditoRecomendado { get; set; }
        public StatusAnaliseFinanceiraDTO Status { get; set; }
        public string Observacoes { get; set; }
    }

    public enum StatusAnaliseFinanceiraDTO
    {
        Aprovado,
        Reprovado,
        Pendente
    }
}
