using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IAutomacaoProcessosRepository
    {
        Task<List<AutomacaoProcessos>> GetAutomacaoProcessosAsync();
        Task<AutomacaoProcessos> CreateAutomacaoProcessosAsync(AutomacaoProcessos automacaoProcessos);
        Task<AutomacaoProcessos> UpdateAutomacaoProcessosAsync(AutomacaoProcessos automacaoProcessos);
        Task DeleteAutomacaoProcessosAsync(string id);
    }
}
