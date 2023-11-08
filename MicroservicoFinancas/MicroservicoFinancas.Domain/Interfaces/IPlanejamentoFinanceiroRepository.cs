using MicroservicoFinancas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IPlanejamentoFinanceiroRepository
    {
        Task<List<PlanejamentoFinanceiro>> GetPlanejamentosFinanceirosAsync();
        Task<PlanejamentoFinanceiro> CreatePlanejamentoFinanceiroAsync(PlanejamentoFinanceiro planejamentoFinanceiro);
        Task<PlanejamentoFinanceiro> UpdatePlanejamentoFinanceiroAsync(PlanejamentoFinanceiro planejamentoFinanceiro);
        Task DeletePlanejamentoFinanceiroAsync(string id);
    }
}
