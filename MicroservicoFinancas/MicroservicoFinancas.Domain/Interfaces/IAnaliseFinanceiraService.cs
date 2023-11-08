using MicroservicoFinancas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Interfaces
{
    public interface IAnaliseFinanceiraService
    {
        Task<List<AnaliseFinanceira>> ObterTodas();
        Task<AnaliseFinanceira> Adicionar(AnaliseFinanceira analiseFinanceira);
        Task<AnaliseFinanceira> Atualizar(AnaliseFinanceira analiseFinanceira);
        void Remover(string analiseFinanceiraId);
    }
}
