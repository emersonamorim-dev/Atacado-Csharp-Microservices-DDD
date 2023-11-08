using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IProcessamentoPagamentosService
    {
        Task<List<ProcessamentoPagamentos>> ObterTodos();
        Task<ProcessamentoPagamentos> Adicionar(ProcessamentoPagamentos processamentoPagamentos);
        Task<ProcessamentoPagamentos> Atualizar(ProcessamentoPagamentos processamentoPagamentos);
        void Remover(string processamentoPagamentosId);
    }
}
