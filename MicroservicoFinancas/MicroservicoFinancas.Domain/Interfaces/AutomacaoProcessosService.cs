using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IAutomacaoProcessosService
    {
        Task<List<AutomacaoProcessos>> ObterTodos();
        Task<AutomacaoProcessos> Adicionar(AutomacaoProcessos automacaoProcessos);
        Task<AutomacaoProcessos> Atualizar(AutomacaoProcessos automacaoProcessos);
        void Remover(string automacaoProcessosId);
    }
}
