using MicroservicoFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Interfaces
{
    public interface IOrcamentoService
    {
        Task<List<Orcamento>> ObterTodos();
        Task<Orcamento> Adicionar(Orcamento orcamento);
        Task<Orcamento> Atualizar(Orcamento orcamento);
        void Remover(string orcamentoId);
    }
}

