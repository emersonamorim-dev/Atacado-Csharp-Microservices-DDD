using MicroservicoFinancas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IAnaliseFinanceiraRepository
    {
        Task<List<AnaliseFinanceira>> GetAnalisesFinanceirasAsync();
        Task<AnaliseFinanceira> CreateAnaliseFinanceiraAsync(AnaliseFinanceira analiseFinanceira);
        Task<AnaliseFinanceira> UpdateAnaliseFinanceiraAsync(AnaliseFinanceira analiseFinanceira);
        Task DeleteAnaliseFinanceiraAsync(string analiseFinanceiraId);
    }
}
