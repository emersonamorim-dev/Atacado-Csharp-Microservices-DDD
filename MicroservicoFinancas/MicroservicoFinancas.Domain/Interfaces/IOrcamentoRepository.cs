using MicroservicoFinancas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IOrcamentoRepository
    {
        Task<List<Orcamento>> GetOrcamentosAsync();
        Task<Orcamento> CreateOrcamentoAsync(Orcamento orcamento);
        Task<Orcamento> UpdateOrcamentoAsync(Orcamento orcamento);
        Task DeleteOrcamentoAsync(string orcamentoId);
    }
}
