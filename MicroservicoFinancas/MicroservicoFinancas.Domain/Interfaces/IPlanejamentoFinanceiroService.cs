using MicroservicoFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Interfaces
{
    public interface IPlanejamentoFinanceiroService
    {
        Task<List<PlanejamentoFinanceiro>> ObterTodos();
        Task<PlanejamentoFinanceiro> Adicionar(PlanejamentoFinanceiro planejamentoFinanceiro);
        Task<PlanejamentoFinanceiro> Atualizar(PlanejamentoFinanceiro planejamentoFinanceiro);
        void Remover(string planejamentoId);
    }
}
