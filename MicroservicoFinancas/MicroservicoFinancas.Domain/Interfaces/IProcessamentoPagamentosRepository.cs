using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IProcessamentoPagamentosRepository
    {
        Task<List<ProcessamentoPagamentos>> GetProcessamentosPagamentosAsync();
        Task<ProcessamentoPagamentos> CreateProcessamentoPagamentosAsync(ProcessamentoPagamentos processamentoPagamentos);
        Task<ProcessamentoPagamentos> UpdateProcessamentoPagamentosAsync(ProcessamentoPagamentos processamentoPagamentos);
        Task DeleteProcessamentoPagamentosAsync(string processamentoPagamentosId);
    }
}
